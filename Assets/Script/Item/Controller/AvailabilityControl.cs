﻿using UnityEngine;

public class AvailabilityControl : MonoBehaviour
{
    [SerializeField] private GameObject[] Grids;
    [SerializeField] private InstantiateMoveControl imController;

    private int xCount;
    private int yCount;

    [SerializeField] private int onGridNum;
    [SerializeField] private int lastGridNum = 0;

    private void Start( )
    {
        onGridNum = -1;
    }

    public void SetGridSize( int x, int y )
    {
        xCount = x;
        yCount = y;
        Grids = new GameObject[x * y];
        imController.setXCount( xCount );
    }

    public void SetGrid( int num, GameObject child )
    {
        Grids[num] = child;
    }

    public void OnGrid( int num )
    {
        if( onGridNum != num )
        {
            lastGridNum = onGridNum;
            onGridNum = num;

            imController.setNowGrid( onGridNum );
            
            DisableLastGrid( );
        }
    }

    private void Update( )
    {
        if( onGridNum != -1 && ( imController.GetIsInstantiating( ) || imController.GetIsMoving( ) ) )
        {
            //caution->enable set return?
            //then show other?
            //caution->getcomponent->slow

            Grids[onGridNum].GetComponent<GridColorControl>( ).EnableAvailability( );

            if(imController.getGOName() == "wood_Instan(Clone)" )
            {
                Grids[onGridNum + xCount].GetComponent<GridColorControl>( ).EnableAvailability( );
            }

            if( imController.getGOName( ) == "grassland_Instan(Clone)" )
            {
                Grids[onGridNum - 1].GetComponent<GridColorControl>( ).EnableAvailability( );
            }

            if( imController.getGOName( ) == "marsh_Instan(Clone)" )
            {
                Grids[onGridNum - 1].GetComponent<GridColorControl>( ).EnableAvailability( );
                Grids[onGridNum + xCount].GetComponent<GridColorControl>( ).EnableAvailability( );
                Grids[onGridNum + xCount - 1].GetComponent<GridColorControl>( ).EnableAvailability( );
            }
        }
    }

    private void DisableLastGrid( )
    {
        if( lastGridNum != -1 )
        {
            Grids[lastGridNum].GetComponent<GridColorControl>( ).DisableAvailability( );

            if( imController.getGOName( ) == "wood_Instan(Clone)" )
            {
                Grids[lastGridNum + xCount].GetComponent<GridColorControl>( ).DisableAvailability( );
            }

            if( imController.getGOName( ) == "grassland_Instan(Clone)" )
            {
                Grids[lastGridNum - 1].GetComponent<GridColorControl>( ).DisableAvailability( );
            }

            if( imController.getGOName( ) == "marsh_Instan(Clone)" )
            {
                Grids[lastGridNum - 1].GetComponent<GridColorControl>( ).DisableAvailability( );
                Grids[lastGridNum + xCount].GetComponent<GridColorControl>( ).DisableAvailability( );
                Grids[lastGridNum + xCount - 1].GetComponent<GridColorControl>( ).DisableAvailability( );
            }
        }
    }

    private void ShowTerritories( int AnimalNum )
    {

    }
}
