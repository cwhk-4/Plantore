using UnityEngine;

public class PointerAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform RectTransform;
    [SerializeField] private Vector2 OriginalVec;
    [SerializeField] private Vector2 TargetVec;
    [SerializeField] private int x = 0;
    [SerializeField] private int y = 0;
    [SerializeField] private int dir = 1;
    [SerializeField] private int distance = 15;

    void Start()
    {
        OriginalVec = RectTransform.anchoredPosition;
    }

    public void ChangePos( Vector2 newPos )
    {
        Debug.Log( newPos + " / " + OriginalVec );
        if( newPos == OriginalVec )
        {
            return;
        }

        RectTransform.anchoredPosition = newPos;
        OriginalVec = newPos;
        x = y = 0;
        dir = 1;
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
