using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowParentAvailability : MonoBehaviour
{
    private void OnMouseOver( )
    {
        if( ItemStorage.isInstantiating )
        {
            GetComponentInParent<ItemStorage>( ).showAvailability( );
        }
    }

    private void OnMouseExit( )
    {
        if( ItemStorage.isInstantiating )
        {
            GetComponentInParent<ItemStorage>( ).closeAvailability( );
        }
    }
}
