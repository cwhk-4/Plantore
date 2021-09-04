using UnityEngine;

public class MissionBannerControl : MonoBehaviour
{
    private RectTransform thisRect;
    [SerializeField] private float count = 0;
    private Vector3 originalPos = new Vector3( 960, 1080 + 75, 0 );
    private int height = 150;

    private void Awake( )
    {
        thisRect = GetComponent<RectTransform>( );
        thisRect.position = originalPos;
    }

    private void FixedUpdate( )
    {
        if( thisRect.position.y > originalPos.y - 150 && count == 0 )
        {
            //down
            thisRect.position = new Vector3( 960, thisRect.position.y - 15, 0 );
        }

        if( thisRect.position.y == originalPos.y - height )
        {
            //stop
            count += Time.fixedDeltaTime;
        }

        if( count >= 3f )
        {
            //up
            thisRect.position = new Vector3( 960, thisRect.position.y + 15, 0 );

            if( thisRect.position.y >= originalPos.y)
            {
                Destroy( gameObject );
            }
        }
    }
}
