using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInstantiate : MonoBehaviour
{
    public GameObject grid;

    private int x;
    private int y;

    private int xGridCount = 4;
    private int yGridCount = 3;

    private float gridWidth = 4.8f;
    private float gridHeight = 3.1f;

    void Start()
    {
        for( y = 0; y < yGridCount; y++ )
        {
            for( x = 0; x < xGridCount; x++ )
            {
                Vector3 gridpos = new Vector3( gridWidth * x - 9.6f, gridHeight * y - 5.4f, 0 );
                var gridInstan = Instantiate( grid, gridpos, Quaternion.identity );
                gridInstan.transform.parent = this.transform;
            }
        }
    }
}
