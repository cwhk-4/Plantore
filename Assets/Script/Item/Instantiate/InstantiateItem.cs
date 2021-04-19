﻿using UnityEngine;

public class InstantiateItem : MonoBehaviour
{
    private InstantiateMoveControl imController;
    private TimeController timeController;
    private GridTerritoryControl territoryControl;

    [SerializeField]private GameObject ItemToInstantiate;
    private GameObject parentGO;
    private Vector3 mousePos = Vector3.zero;
    private float thisStartingTime;

    private void Start( )
    {
        timeController = GameObject.Find( "System" ).GetComponent<TimeController>( );
        imController = GameObject.FindWithTag( "InstantiateMoveControl" ).GetComponent<InstantiateMoveControl>( );
        territoryControl = GameObject.Find( "TerritoryController" ).GetComponent<GridTerritoryControl>( );
        imController.setGOName( name );
        thisStartingTime = timeController.getNowRealSec( );
    }

    private void Update( )
    {
        mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos = new Vector3( mousePos.x, mousePos.y, 0 );
        transform.position = mousePos;

        if( parentGO == null )
        {
            return;
        }

        if( Input.GetMouseButton( 0 ) && parentGO.transform.childCount == 0)
        {
            var available = imController.CheckThisGrid( );

            if( !available )
            {
                return;
            }

            switch( name )
            {
                case "grass_Instan(Clone)":
                    available = true;
                    break;

                case "wood_Instan(Clone)":
                    available = imController.CheckWoodGrid( );
                    break;

                case "grassland_Instan(Clone)":
                    available = imController.CheckGrasslandGrid( );
                    break;

                case "marsh_Instan(Clone)":
                    available = imController.CheckMarshGrid( );
                    break;

                //caution -> new function needed
                case "rock_Instan(Clone)":
                    available = imController.CheckMarshGrid( );
                    break;
            }

            if( !available )
            {
                return;
            }

            var item = Instantiate( ItemToInstantiate, mousePos, Quaternion.identity );
            item.transform.SetParent( parentGO.transform );
            item.transform.position = parentGO.transform.position;

            var index = parentGO.transform.GetSiblingIndex( );
            Debug.Log( index );

            switch( name )
            {
                case "grass_Instan(Clone)":
                    territoryControl.SetItem( index, ( int )Define.ITEM.GRASS );
                    break;

                case "wood_Instan(Clone)":
                    territoryControl.SetItem( index, ( int )Define.ITEM.WOOD );
                    break;

                case "rock_Instan(Clone)":
                    territoryControl.SetItem( index, ( int )Define.ITEM.ROCK );
                    break;
            }

            if( name != "grass_Instan(Clone)" )
            {
                imController.InstantiateExtraGrid( name );
            }

            //tutorial
            if( name != "Tutorial_grass(Clone)" )
            {
                if( imController.GetIsMoving( ) )
                {
                    var timeDelayed = timeController.getNowRealSec( ) - thisStartingTime;
                    item.GetComponent<CountDown>( ).setStartingTime( imController.GetStartingTime( ) + timeDelayed );
                    Debug.Log( timeDelayed );
                }
                else
                {
                    item.GetComponent<CountDown>( ).setStartingTime( timeController.getNowRealSec( ) );
                }

            }
            //tutorial end

            Destroy( gameObject );
        }
    }

    public void SetParentGO( GameObject parent )
    {
        parentGO = parent;
    }

    public GameObject getParentGO( )
    {
        return parentGO;
    }

    private void OnDestroy( )
    {
        imController.FinishInstantiate( );
        imController.FinishMoving( );
    }
}
