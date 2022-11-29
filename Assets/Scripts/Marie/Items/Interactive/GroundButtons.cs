using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButtons : Interactive
{
    public KeyItemData bag;
    public GameObject ironDoor;

    public static int button_check = 0;
    public override void OnInteraction()
    {
        Inventory.Instance.RemoveFromInventory(bag);
        transform.GetChild(0).gameObject.SetActive(true);
        if (transform.parent.name == "GoodButtons")
        {
            button_check++;
            if (button_check == 4)
            {
                ironDoor = GameObject.Find("Portcullis_Wood");
                Debug.Log("T'as réussi l'énigme");
            }
        }
    }
}
