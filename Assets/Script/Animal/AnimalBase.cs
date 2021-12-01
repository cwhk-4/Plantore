using UnityEngine;
using System.Collections.Generic;

public class AnimalBase : MonoBehaviour
{
    private AnimalData.AnimalBase _animal = new AnimalData.AnimalBase( );

    private TimeController TimeController;
    private ReactionControl ReactionControl;
    private MapLevel MapLevel;
    private MissionControl MissionControl;

    private Transform GridParent;
    private Transform AnimalParent;
    private Transform CameraTransform;

    private float StartingCD = 5f;
    private float ActionCD = 3f;
    private List<int> HuntingList = new List<int>( );
    private List<int> FightingList = new List<int>( );

    #region Init
    public void Init( int animal_type, int target_index, int target_type, Transform grid_parent, Transform animal_parent, Transform main_camera,
                      MapLevel map_level, ReactionControl reaction_control, MissionControl mission_control ,TimeController time_controller )
    {
        _animal.AnimalType = animal_type;
        _animal.TargetIndex = target_index;
        _animal.TargetType = target_type;

        GridParent = grid_parent;
        _animal.TargetPos = GridParent.GetChild( target_index ).position;

        AnimalParent = animal_parent;
        CameraTransform = main_camera;

        MapLevel = map_level;
        ReactionControl = reaction_control;
        MissionControl = mission_control;

        TimeController = time_controller;
        _animal.CDStartingTime = TimeController.GetNowSec( );
        _animal.Speed = 5f;

        _animal.OriginalPos = RandomPos( );
        this.transform.parent = AnimalParent;
        this.transform.position = _animal.OriginalPos;


        _animal.State = ( int )AnimalData.ANIMAL_STATE.STARTING_CD;

        _animal.IsCarnivore = CheckCarnivore( );

        _animal.Territory = ItemData.TERRITORY_ARR[_animal.TargetType];

        gameObject.SetActive( true );
    }

    private Vector3 RandomPos()
    {
        var x = -13f;

        var TargetX = _animal.TargetIndex % Define.XCOUNT;
        var CameraCenter = Mathf.FloorToInt( CameraTransform.position.x / 3.2f ) + 3;

        if( CameraCenter > TargetX )
        {
            x = -13f;
            gameObject.GetComponent<SpriteRenderer>( ).flipX = true;
        }
        else
        {
            x = 25f;
            gameObject.GetComponent<SpriteRenderer>( ).flipX = false;
        }

        var level = MapLevel.GetMapLevel( ) - 1;

        var y = Random.Range( -7, 7 + level );

        return new Vector3( x, y, 0 );
    }

    private bool CheckCarnivore( )
    {
        for( int i = 0; i < AnimalData.CARNIVORE.Length; i++ )
        {
            if(_animal.AnimalType == AnimalData.CARNIVORE[i])
            {
                _animal.TypeNum = i;

                HuntingList.Clear( );
                FightingList.Clear( );

                _animal.IsActionable = AnimalData.CARN_ACTIONABLE_PERIOD[i];

                return true;
            }
        }

        SetHerbNum( );
        return false;
    }

    private void SetHerbNum( )
    {
        for( int i = 0; i < AnimalData.HERBIVORE.Length; i++ )
        {
            if( _animal.AnimalType == AnimalData.HERBIVORE[i] )
            {
                _animal.TypeNum = i;
                _animal.IsActionable = new bool[3] { true, true, true };
                return;
            }
        }
    }
    #endregion

    private void FixedUpdate( )
    {
        int Period = TimeController.GetNowPeriod( );

        switch(_animal.State)
        {
            case ( int )AnimalData.ANIMAL_STATE.LEAVE_ITEM:
                this.transform.position = Vector3.MoveTowards( this.transform.position, _animal.TargetPos, Time.deltaTime * _animal.Speed );
                break;

            case ( int )AnimalData.ANIMAL_STATE.STARTING_CD:
                if( TimeController.GetNowSec( ) - _animal.CDStartingTime >= StartingCD )
                {
                    _animal.CDStartingTime = TimeController.GetNowSec( );
                    _animal.State = ( int )AnimalData.ANIMAL_STATE.STARTING_PATROL;
                }
                break;

            case ( int )AnimalData.ANIMAL_STATE.STARTING_PATROL:
                this.transform.position = Vector3.MoveTowards( this.transform.position, _animal.TargetPos, Time.deltaTime * _animal.Speed );
                if( this.transform.position == _animal.TargetPos )
                {
                    _animal.CDStartingTime = TimeController.GetNowSec( );
                    _animal.State = ( int )AnimalData.ANIMAL_STATE.COOL_DOWN;
                }
                break;
        
            case ( int )AnimalData.ANIMAL_STATE.COOL_DOWN:
                if( TimeController.GetNowSec( ) - _animal.CDStartingTime >= ActionCD )
                {
                    _animal.State = ( int )AnimalData.ANIMAL_STATE.DECIDING;
                }
                break;

            case ( int )AnimalData.ANIMAL_STATE.DECIDING:
                MakeDecision( Period );
                break;

            case ( int )AnimalData.ANIMAL_STATE.PATROL:
                this.transform.position = Vector3.MoveTowards( this.transform.position, _animal.TargetPos, Time.deltaTime * _animal.Speed );
                if( this.transform.position == _animal.TargetPos )
                {
                    _animal.CDStartingTime = TimeController.GetNowSec( );
                    _animal.State = ( int )AnimalData.ANIMAL_STATE.COOL_DOWN;
                }
                break;

            case ( int )AnimalData.ANIMAL_STATE.WAITING_FOR_HUNTING:
                this.transform.position = Vector3.MoveTowards( this.transform.position, _animal.TargetPos, Time.deltaTime * _animal.Speed );

                if( this.transform.position == _animal.TargetPos )
                {
                    _animal.State = ( int )AnimalData.ANIMAL_STATE.HUNTING;
                }

                break;

            case ( int )AnimalData.ANIMAL_STATE.WAITING_FOR_FIGHTING:
                this.transform.position = Vector3.MoveTowards( this.transform.position, _animal.TargetPos, Time.deltaTime * _animal.Speed );

                if( this.transform.position == _animal.TargetPos )
                {
                    _animal.State = ( int )AnimalData.ANIMAL_STATE.FIGHTING;
                }

                break;

            case ( int )AnimalData.ANIMAL_STATE.HUNTING:
                ReactionControl.StartHunting( );
                break;

            case ( int )AnimalData.ANIMAL_STATE.FIGHTING:
                ReactionControl.StartFighting( );
                break;

            case ( int )AnimalData.ANIMAL_STATE.REST:
                if( this.transform.position != _animal.TargetPos )
                {
                    this.transform.position = Vector3.MoveTowards( this.transform.position, _animal.TargetPos, Time.deltaTime * _animal.Speed );
                }

                if( _animal.IsActionable[Period] )
                {
                    _animal.State = ( int )AnimalData.ANIMAL_STATE.DECIDING;
                }
                break;

        }
    }

    private void MakeDecision( int period )
    {
        if( !_animal.IsActionable[period] )
        {
            _animal.TargetPos = GridParent.GetChild( _animal.TargetIndex ).position;
            _animal.State = ( int )AnimalData.ANIMAL_STATE.REST;
            ChangeDir( );
            return;
        }

        if( !_animal.IsCarnivore )
        {
            RandomTarget( );
        }
        else
        {
            CheckTerritory( );

            bool hvTarget = false;
            if( FightingList.Count > 0 || HuntingList.Count > 0 )
            {
                hvTarget = true;
            }

            if( hvTarget )
            {
                SetTarget( );
            }
            else
            {
                RandomTarget( );
            }
        }
    }

    #region Action
    private void ChangeDir()
    {
        //left = false right = true
        if( transform.position.x >= _animal.TargetPos.x )
        {
            gameObject.GetComponent<SpriteRenderer>( ).flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>( ).flipX = true;
        }
    }

    private void CheckTerritory( )
    {
        FightingList.Clear( );
        HuntingList.Clear( );

        for( int i = 1; i < _animal.Territory.Length; i++ )
        {
            int index = _animal.TargetIndex + _animal.Territory[i];
            bool isOccupied = false;

            if( CheckNotOpposite( index ) && CheckInRange( index ) )
            {
                isOccupied = GridParent.GetChild( index ).GetComponent<GridBase>( ).GetIfOccupied( );
            }

            if( isOccupied )
            {
                if( GridParent.GetChild( index ).GetComponent<GridBase>( ).GetIsCarnTerr( ) )
                {
                    FightingList.Add( index );
                }
                else
                {
                    HuntingList.Add( index );
                }
            }
        }
    }

    private void SetTarget( )
    {
        //fighting
        if( FightingList.Count > 0 )
        {
            int target = FightingList[0];

            //request
            while( ReactionControl.RequestAction( this.gameObject, target ) )
            {
                //still availble?
                GameObject targetGO = GridParent.GetChild( target ).GetComponent<GridBase>( ).GetAnimal( );

                //target get is self?
                if( targetGO == this.gameObject )
                {
                    targetGO = GridParent.GetChild( target ).GetComponent<GridBase>( ).GetAnimalbyIndex( 1 );
                }

                //still alive?
                if( targetGO == null )
                {
                    //not available then reset and return
                    _animal.TargetPos = GridParent.GetChild( _animal.TargetIndex ).position;
                    _animal.State = ( int )AnimalData.ANIMAL_STATE.PATROL;
                    ChangeDir( );
                    return;
                }

                //on item?
                if( targetGO.GetComponent<AnimalBase>( ).GetAnimalState( ) <= ( int )AnimalData.ANIMAL_STATE.STARTING_PATROL )
                {
                    _animal.TargetPos = GridParent.GetChild( _animal.TargetIndex ).position;
                    _animal.State = ( int )AnimalData.ANIMAL_STATE.PATROL;
                    ChangeDir( );
                    return;
                }

            }

            GameObject targetAnimal = GridParent.GetChild( target ).GetComponent<GridBase>( ).GetAnimal( );

            if( targetAnimal == this.gameObject )
            {
                targetAnimal = GridParent.GetChild( target ).GetComponent<GridBase>( ).GetAnimalbyIndex( 1 );
            }

            if( targetAnimal == null )
            {
                _animal.TargetPos = GridParent.GetChild( _animal.TargetIndex ).position;
                _animal.State = ( int )AnimalData.ANIMAL_STATE.PATROL;
                ChangeDir( );
                return;
            }

            if( targetAnimal.GetComponent<AnimalBase>( ).GetAnimalState( ) <= ( int )AnimalData.ANIMAL_STATE.STARTING_PATROL )
            {
                _animal.TargetPos = GridParent.GetChild( _animal.TargetIndex ).position;
                _animal.State = ( int )AnimalData.ANIMAL_STATE.PATROL;
                ChangeDir( );
                return;
            }

            _animal.TargetPos = targetAnimal.transform.position;

            _animal.State = ( int )AnimalData.ANIMAL_STATE.WAITING_FOR_FIGHTING;

            _animal.CDStartingTime = TimeController.GetNowSec( );

            return;
        }

        //hunting
        if( HuntingList.Count > 0 )
        {
            var target = HuntingList[0];

            //request
            while( ReactionControl.RequestAction( this.gameObject, target ) )
            {
                //check still availble?
                GameObject targetGO = GridParent.GetChild( target ).GetComponent<GridBase>( ).GetAnimal( );

                if( targetGO == this.gameObject )
                {
                    targetGO = GridParent.GetChild( target ).GetComponent<GridBase>( ).GetAnimalbyIndex( 1 );
                }

                if( targetGO == null )
                {
                    //not available then reset and return
                    _animal.TargetPos = GridParent.GetChild( _animal.TargetIndex ).position;
                    _animal.State = ( int )AnimalData.ANIMAL_STATE.PATROL;
                    ChangeDir( );
                    return;
                }

                if( targetGO.GetComponent<AnimalBase>( ).GetAnimalState( ) <= ( int )AnimalData.ANIMAL_STATE.STARTING_PATROL )
                {
                    _animal.TargetPos = GridParent.GetChild( _animal.TargetIndex ).position;
                    _animal.State = ( int )AnimalData.ANIMAL_STATE.PATROL;
                    ChangeDir( );
                    return;
                }

            }

            GameObject targetAnimal = GridParent.GetChild( target ).GetComponent<GridBase>( ).GetAnimal( );

            if( targetAnimal == gameObject )
            {
                targetAnimal = GridParent.GetChild( target ).GetComponent<GridBase>( ).GetAnimalbyIndex( 1 );
            }

            if( targetAnimal == null )
            {
                _animal.TargetPos = GridParent.GetChild( _animal.TargetIndex ).position;
                _animal.State = ( int )AnimalData.ANIMAL_STATE.PATROL;
                ChangeDir( );
                return;
            }

            if( targetAnimal.GetComponent<AnimalBase>( ).GetAnimalState( ) <= ( int )AnimalData.ANIMAL_STATE.STARTING_PATROL )
            {
                _animal.TargetPos = GridParent.GetChild( _animal.TargetIndex ).position;
                _animal.State = ( int )AnimalData.ANIMAL_STATE.PATROL;
                ChangeDir( );
                return;
            }

            _animal.TargetPos = targetAnimal.transform.position;
            _animal.State = ( int )AnimalData.ANIMAL_STATE.WAITING_FOR_HUNTING;
            ChangeDir( );

            _animal.CDStartingTime = TimeController.GetNowSec( );

        }

    }

    //finish action and go back to patrol mode
    public void BackToPatrol( bool isSuccess )
    {
        if( isSuccess )
        {
            if( _animal.State == ( int )AnimalData.ANIMAL_STATE.FIGHTING )
            {
                FightingList.RemoveAt( 0 );
            }

            if( _animal.State == ( int )AnimalData.ANIMAL_STATE.HUNTING )
            {
                HuntingList.RemoveAt( 0 );
            }

            if( _animal.AnimalType == ( int )Define.ANIMAL.LION )
            {
                MissionControl.HuntedByLion( );
            }
            MissionControl.HuntingSucceed( );
        }
        else
        {
            if( _animal.State == ( int )AnimalData.ANIMAL_STATE.FIGHTING )
            {
                var targetIndex = FightingList[0];
                FightingList.RemoveAt( 0 );
                FightingList.Add( targetIndex );
            }

            if( _animal.State == ( int )AnimalData.ANIMAL_STATE.HUNTING )
            {
                var targetIndex = HuntingList[0];
                HuntingList.RemoveAt( 0 );
                HuntingList.Add( targetIndex );
            }
        }

        _animal.TargetPos = GridParent.GetChild( _animal.TargetIndex ).position;
        _animal.State = ( int )AnimalData.ANIMAL_STATE.PATROL;
        ChangeDir( );
    }

    //destory
    public void Hunted( )
    {
        GridParent.GetChild( _animal.TargetIndex ).GetComponent<GridBase>( ).AnimalDestoryed( _animal.TargetType, _animal.AnimalType, gameObject );
        GridParent.GetChild( _animal.TargetIndex ).GetComponent<GridBase>( ).RemoveMainAnimal( );
        GridParent.GetChild( _animal.TargetIndex ).GetChild( 0 ).GetComponent<ItemBase>( ).AnimalRemoved( );
        Destroy( gameObject );
    }

    #endregion

    #region ItemRelatedAction
    //back to original pos immediately
    public void ItemTimedOut( )
    {
        _animal.TargetPos = _animal.OriginalPos;
        _animal.State = ( int )AnimalData.ANIMAL_STATE.LEAVE_ITEM;
        ChangeDir( );
    }

    //item fixed
    public void ItemFixed( )
    {
        _animal.TargetPos = GridParent.GetChild( _animal.TargetIndex ).position;
        _animal.State = ( int )AnimalData.ANIMAL_STATE.PATROL;
        ChangeDir( );
    }

    //call after environment finished moving
    public void EnvironmentMoved( int index )
    {
        _animal.TargetIndex = index;
        _animal.TargetPos = GridParent.GetChild( _animal.TargetIndex ).position;
        _animal.CDStartingTime = TimeController.GetNowSec( );
        _animal.State = ( int )AnimalData.ANIMAL_STATE.PATROL;
        ChangeDir( );
    }
    #endregion

    #region Patrol
    private void RandomTarget( )
    {
        int rand = RandomTerritory( );
        int target = _animal.TargetIndex + _animal.Territory[rand];

        Debug.Log( target );
        _animal.TargetPos = GridParent.GetChild( target ).position;
        ChangeDir( );

        _animal.CDStartingTime = TimeController.GetNowSec( );
        _animal.State = ( int )AnimalData.ANIMAL_STATE.PATROL;
    }

    private int RandomTerritory( )
    {
        int rand = Random.Range( 0, _animal.Territory.Length );
        int index = _animal.TargetIndex + _animal.Territory[rand];

        while( !( CheckNotOpposite( index ) && CheckInRange( index ) ) )
        {
            rand = Random.Range( 0, _animal.Territory.Length );
            index = _animal.TargetIndex + _animal.Territory[rand];
        }

        return rand;
    }
    #endregion

    #region GetData
    public int GetTypeNum( )
    {
        return _animal.TypeNum;
    }

    public int GetAnimalNum( )
    {
        return _animal.AnimalType;
    }

    public int GetAnimalState( )
    {
        return _animal.State;
    }

    public bool GetOnItem( )
    {
        if( _animal.State > ( int )AnimalData.ANIMAL_STATE.STARTING_PATROL )
        {
            return true;
        }

        return false;
    }
    #endregion

    #region Cheating
    public void CallImmediatelyFromStartingCD( )
    {
        _animal.CDStartingTime = TimeController.GetNowSec( );
        _animal.State = ( int )AnimalData.ANIMAL_STATE.STARTING_PATROL;
    }
    #endregion

    #region Checking
    private bool CheckNotOpposite( int index )
    {
        int targetX = index % Define.XCOUNT;

        int selfX = _animal.TargetIndex % Define.XCOUNT;

        if(selfX == 0)
        {
            if( targetX >= Define.XCOUNT - 3 )
            {
                return false;
            }
        }

        if(selfX == Define.XCOUNT - 1 )
        {
            if( targetX <= 3 )
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckInRange(int index)
    {
        if( index < 0 || index > Define.XCOUNT * Define.YCOUNT )
        {
            return false;
        }

        return true;
    }
    #endregion
}
