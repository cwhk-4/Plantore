using UnityEngine;

public class PointerAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform RectTransform;
    [SerializeField] private Vector2 OriginalVec;
    [SerializeField] private Vector2 TargetVec;
    [SerializeField] private float x = 0;
    [SerializeField] private float y = 0;
    [SerializeField] private float dir = 0.75f;
    [SerializeField] private int distance = 15;

    void Start()
    {
        OriginalVec = RectTransform.anchoredPosition;
    }

    void Init( )
    {
        x = y = 0;
        if( dir < 0 )
        {
            dir *= -1;
        }
    }

    public void ChangePos( Vector2 newPos )
    {
        if( newPos == OriginalVec )
        {
            return;
        }

        RectTransform.anchoredPosition = newPos;
        OriginalVec = newPos;
        Init( );
    }

    private void Update( )
    {
        TargetVec = new Vector2( OriginalVec.x + x, OriginalVec.y + y );
        RectTransform.anchoredPosition = TargetVec;

        x += dir;
        y += -dir;
        if( x >= distance || x <= 0 )
        {
            dir *= -1;
        }

    }
}
