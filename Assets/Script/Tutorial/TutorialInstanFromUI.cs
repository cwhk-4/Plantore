﻿using UnityEngine;

public class TutorialInstanFromUI : MonoBehaviour
{
    [SerializeField] private TutorialIMController imController;

    public void itemInstantiate( GameObject itemToBeInstantiate )
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos = new Vector3( mousePos.x, mousePos.y, 0 );
        var item = Instantiate( itemToBeInstantiate, mousePos, Quaternion.identity );
        imController.StartInstantiate( );
    }
}
