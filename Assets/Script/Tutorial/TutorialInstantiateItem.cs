using UnityEngine;

public class TutorialInstantiateItem : MonoBehaviour
{
    private TutorialIMController imController;

    [SerializeField] private GameObject ItemToInstantiate;
    private GameObject parentGO;
    private Vector3 mousePos = Vector3.zero;

    private float BufferTime = 1f;
    private bool buffer = true;

    private void Start( )
    {
        imController = FindObjectOfType<TutorialIMController>( );
        imController.setGOName( name );
        buffer = true;
    }

    private void FixedUpdate( )
    {
        if( BufferTime >= 0 )
        {
            BufferTime -= Time.fixedDeltaTime;

            if( BufferTime <= 0 )
            {
                buffer = false;
            }
        }
    }

    private void Update( )
    {
        mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos = new Vector3( mousePos.x, mousePos.y, 0 );
        transform.position = mousePos;

        if( Input.GetMouseButton( 0 ) && parentGO.transform.childCount == 0 && !buffer )
        {
            var available = imController.CheckThisGrid( );

            if( !available )
            {
                return;
            }

            var item = Instantiate( ItemToInstantiate, mousePos, Quaternion.identity );
            item.transform.SetParent( parentGO.transform );
            item.transform.position = parentGO.transform.position;

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
