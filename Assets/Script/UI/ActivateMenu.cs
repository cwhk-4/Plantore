using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenu: MonoBehaviour
{
    public GameObject Menu;

    public void disableMenuButton()
    {
        Menu.SetActive( false );
    }

    public void enableMenuButton()
    {
        Menu.SetActive( true );
    }
}
