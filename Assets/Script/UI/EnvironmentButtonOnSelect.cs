using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnvironmentButtonOnSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;

    [SerializeField] private Sprite OnSelectImage;
    [SerializeField] private Sprite NormalImage;

    private void Start( )
    {
        image = GetComponent<Image>( );
        image.sprite = NormalImage;
    }

    public void OnPointerExit( PointerEventData eventData )
    {
        image.sprite = NormalImage;
        image.SetNativeSize( );
    }

    public void OnPointerEnter( PointerEventData eventData )
    {
        image.sprite = OnSelectImage;
        image.SetNativeSize( );
    }

    public void ReturnToDef( )
    {
        image.sprite = NormalImage;
        image.SetNativeSize( );
    }

}
