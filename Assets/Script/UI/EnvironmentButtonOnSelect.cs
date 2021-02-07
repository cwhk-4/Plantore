using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnvironmentButtonOnSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RawImage ParentImage;

    [SerializeField] private Texture OnSelectImage;
    [SerializeField] private Texture NormalImage;

    void Start()
    {
        ParentImage = GetComponentInParent<RawImage>( );
    }

    public void OnPointerExit( PointerEventData eventData )
    {
        ParentImage.texture = NormalImage;
    }

    public void OnPointerEnter( PointerEventData eventData )
    {
        ParentImage.texture = OnSelectImage;
    }

}
