using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUIInstantiate : MonoBehaviour
{
    public GameObject instantiateController;

    public void itemInstantiate( GameObject itemToBeInstantiate )
    {
        if( itemToBeInstantiate == null )
        {
            itemToBeInstantiate = instantiateController;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos = new Vector3( mousePos.x, mousePos.y, 0 );
        var item = Instantiate( itemToBeInstantiate, mousePos, Quaternion.identity );
        ItemStorage.isInstantiating = true;
    }

}