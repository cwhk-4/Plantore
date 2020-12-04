using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIControl : MonoBehaviour
{
    public GameObject Menu;

    void Start()
    {
        closeMenu();
        Time.timeScale = 1;
    }

    public void openMenu()
    {
        Menu.SetActive( true );
        Time.timeScale = 0;
    }

    public void closeMenu()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
    }


}
