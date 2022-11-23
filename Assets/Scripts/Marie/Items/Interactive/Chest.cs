using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactive
{
    public KeyItemData key;
    public override void OnInteraction()
    {
        //If I want to do the base OnInteraction anyway first
        //
        //Activate light and fire
        Inventory.Instance.PickupKeyItem(key);
    }
}
