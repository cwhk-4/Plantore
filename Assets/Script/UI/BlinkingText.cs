using UnityEngine;
using TMPro;

public class BlinkingText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private float BlinkingSpeed;

    private Color color;

    void Start()
    {
        text = GetComponent<TMP_Text>( );
        color = Color.white;
        color.a = 0;
    }

    void Update()
    {
        if( gameObject.activeSelf )
        {
            color.a = Mathf.Sin( Time.time * BlinkingSpeed ) / 2 + 0.5f;
            text.color = color;
        }
    }
}
