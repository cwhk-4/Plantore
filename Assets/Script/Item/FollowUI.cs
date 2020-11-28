using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowUI : MonoBehaviour
{
    private GameObject canvas;
    public Transform target;
    private Vector3 targetPos;
    private int distance;

    private void Start( )
    {
        canvas = this.transform.parent.gameObject;
        target = canvas.transform.parent;

        if( this.GetComponent<Slider>( ) != null )
        {
            distance = 110;
        }

        if( this.GetComponent<Text>( ) != null )
        {
            distance = 160;
        }
    }

    void Update()
    {
        targetPos = Camera.main.WorldToScreenPoint( target.position );
        targetPos = new Vector3( targetPos.x, targetPos.y - distance, targetPos.z );
        this.transform.position = targetPos;
    }
}
