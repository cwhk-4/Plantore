using UnityEngine;
using UnityEngine.UI;

public class TitleContinueButton : MonoBehaviour
{
    [SerializeField] private Sprite ActiveImage;
    [SerializeField] private Sprite InactiveImage;

    [SerializeField] private Image ButtonImage;
    [SerializeField] private Button Button;

    void Start()
    {
        Button.interactable = false;
        ButtonImage.sprite = InactiveImage;
    }
}
