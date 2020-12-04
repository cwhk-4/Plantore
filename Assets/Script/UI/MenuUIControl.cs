using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIControl : MonoBehaviour
{
    public GameObject Menu;
    public GameObject MenuButton;

    void Start()
    {
        closeMenu();
        Time.timeScale = 1;
    }

    public void openMenu()
    {
        Menu.SetActive(true);
        MenuButton.SetActive( false );
        Time.timeScale = 0;
    }

    public void closeMenu()
    {
        Menu.SetActive(false);
        MenuButton.SetActive( true );
        Time.timeScale = 1;
    }


}
