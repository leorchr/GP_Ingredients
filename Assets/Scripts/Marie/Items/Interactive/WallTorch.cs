using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTorch : Interactive
{
    public static int litTorchesCount = 0;
    public GameObject chest;
    public KeyItemData litTorch;
    public override void OnInteraction()
    {
        //If I want to do the base OnInteraction anyway first
        //
        //Activate light and fire
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        litTorchesCount++;
        if(litTorchesCount == 3)
        {
            Inventory.Instance.RemoveFromInventory(litTorch);
            chest.SetActive(true);
        }
    }
}
