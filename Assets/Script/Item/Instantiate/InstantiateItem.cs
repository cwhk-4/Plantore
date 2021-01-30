﻿using UnityEngine;

public class InstantiateItem : MonoBehaviour
{
    private InstantiateMoveControl imController;
    private TimeController timeController;

    [SerializeField]private GameObject ItemToInstantiate;
    private GameObject parentGO;
    private Vector3 mousePos = Vector3.zero;
    private float thisStartingTime;

    private void Start( )
    {
        timeController = GameObject.Find( "System" ).GetComponent<TimeController>( );
        imController = GameObject.FindWithTag( "InstantiateMoveControl" ).GetComponent<InstantiateMoveControl>( );
        imController.setGOName( name );
        thisStartingTime = timeController.getNowRealSec( );
    }

    private void Update( )
    {
        mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos = new Vector3( mousePos.x, mousePos.y, 0 );
        transform.position = mousePos;

        if( Input.GetMouseButton( 0 ) && parentGO != null)
        {
            var available = false;

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
            }

            if( !available )
            {
                return;
            }

            var item = Instantiate( ItemToInstantiate, mousePos, Quaternion.identity );
            item.transform.SetParent( parentGO.transform );
            item.transform.position = parentGO.transform.position;

            if( name != "grass_Instan(Clone)" )
            {
                imController.InstantiateExtraGrid( name );
            }

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
