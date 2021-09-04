using UnityEngine;

public class MissionBoxControl : MonoBehaviour
{
    private void Start( )
    {
        transform.localScale = Vector3.zero;
    }

    private void Update( )
    {
        if( transform.localScale != Vector3.one )
        {
            transform.localScale = new Vector3( transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f );
        }
    }

    public void CloseBox( )
    {
        Destroy( gameObject.transform.parent.gameObject );
    }
}
