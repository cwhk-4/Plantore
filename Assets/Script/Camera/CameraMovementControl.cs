using UnityEngine;
using UnityEngine.UI;

public class CameraMovementControl : MonoBehaviour
{
    [SerializeField] private MapLevel mapLevel;

    [SerializeField] private Transform camPos;

    [SerializeField] private Button Up;
    [SerializeField] private Button Down;
    [SerializeField] private Button Left;
    [SerializeField] private Button Right;

    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private bool moveDown;

    [SerializeField]
    private int level = 0;
    [SerializeField]
    private float vertLimit = 0f;
    [SerializeField]
    private float horiLimit = 0f;

    public float speed = 1f;

    private Color buttonColor;
    private Color buttonTransColor;

    private void Start()
    {
        moveLeft = false;
        moveRight = false;
        moveUp = false;
        moveDown = false;
        buttonColor = Up.image.color;
        buttonTransColor = Up.image.color;
        buttonTransColor.a = 0;

        LevelCheck( );
        CamMovement( );
        CamLimitCheck( );
    }

    private void Update()
    {
        LevelCheck( );
    }

    void LateUpdate()
    {
        if( level > 1 )
        {
            if( moveLeft || moveRight || moveUp || moveDown )
            {
                CamMovement( );
            }
        }

        CamLimitCheck( );
    }

    public void PointerDownLeft()
    {
        LevelCheck( );
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        LevelCheck( );
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    public void PointerDownUp()
    {
        LevelCheck( );
        moveUp = true;
    }

    public void PointerUpUp()
    {
        moveUp = false;
    }

    public void PointerDownDown()
    {
        LevelCheck( );
        moveDown = true;
    }

    public void PointerUpDown()
    {
        moveDown = false;
    }

    private void CamMovement()
    {
        Vector3 pos = camPos.position;
        if (moveLeft)
        {
            pos.x -= speed * Time.deltaTime;
        }

        if (moveRight)
        {
            pos.x += speed * Time.deltaTime;
        }

        if (moveUp)
        {
            pos.y += speed * Time.deltaTime;
        }

        if (moveDown)
        {
            pos.y -= speed * Time.deltaTime;
        }

        camPos.position = pos;
    }

    private void CamLimitCheck()
    {
        if (camPos.position.x <= 0)
        {
            camPos.position = new Vector3(0, camPos.position.y, camPos.position.z);
            Left.interactable = false;
            Left.image.color = buttonTransColor;
        }
        else
        {
            Left.interactable = true;
            Left.image.color = buttonColor;
        }

        if (camPos.position.y <= 0)
        {
            camPos.position = new Vector3(camPos.position.x, 0, camPos.position.z);
            Down.interactable = false;
            Down.image.color = buttonTransColor;
        }
        else
        {
            Down.interactable = true;
            Down.image.color = buttonColor;
        }

        if (camPos.position.x >= horiLimit)
        {
            camPos.position = new Vector3(horiLimit, camPos.position.y, camPos.position.z);
            Right.interactable = false;
            Right.image.color = buttonTransColor;
        }
        else
        {
            Right.interactable = true;
            Right.image.color = buttonColor;
        }

        if (camPos.position.y >= vertLimit)
        {
            camPos.position = new Vector3(camPos.position.x, vertLimit, camPos.position.z);
            Up.interactable = false;
            Up.image.color = buttonTransColor;
        }
        else
        {
            Up.interactable = true;
            Up.image.color = buttonColor;
        }
    }

    private void LevelCheck()
    {
        level = mapLevel.getMapLevel();

        switch (level)
        {
            case 1:
                vertLimit = 0f;
                horiLimit = 0f;
                break;
            case 2:
                vertLimit = 3.6f;
                horiLimit = 6.4f;
                break;
            case 3:
                vertLimit = 7.2f;
                horiLimit = 12.8f;
                break;
            case 4:
                vertLimit = 10.8f;
                horiLimit = 19.2f;
                break;
        }
    }
}


