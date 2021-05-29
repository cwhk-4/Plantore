using UnityEngine;

public class FollowUI : MonoBehaviour
{
    //test
    private GameObject canvas;
    public Transform target;
    private Vector3 targetPos;
    [SerializeField] private int distance;
    [SerializeField] private int xdistance;

    private void Start( )
    {
        canvas = this.transform.parent.gameObject;
        target = canvas.transform.parent;
    }

    void Update()
    {
        targetPos = Camera.main.WorldToScreenPoint( target.position );
        targetPos = new Vector3( targetPos.x + xdistance, targetPos.y - distance, targetPos.z );
        this.transform.position = targetPos;
    }
}
