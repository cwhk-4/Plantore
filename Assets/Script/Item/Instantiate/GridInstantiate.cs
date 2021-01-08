﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject grid;
    [SerializeField] private AvailabilityControl availabilityControl;

    private int x;
    private int y;

    private int xGridCount = 8;
    private int yGridCount = 6;

    private float gridWidth = 4.8f;
    private float gridHeight = 3.1f;

    private int totalGridCount = 0;

    void Start()
    {
        availabilityControl.SetGridSize( xGridCount, yGridCount );

        for( y = 0; y < yGridCount; y++ )
        {
            for( x = 0; x < xGridCount; x++ )
            {
                Vector3 gridpos = new Vector3( gridWidth * x - 9.6f + gridWidth / 2, gridHeight * y - 5.4f + gridHeight / 2, 0 );
                var gridInstan = Instantiate( grid, gridpos, Quaternion.identity );
                gridInstan.transform.parent = this.transform;

                var gridName = "x" + x + "y" + y;
                gridInstan.name = gridName;

                availabilityControl.SetGrid( totalGridCount, gridInstan );
                totalGridCount++;
            }
        }
    }
}