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
        Debug.Log("Tu marches sur moi frérot");
        if (transform.parent.name == "GoodButtons")
        {
            button_check++;
            Debug.Log("+1");
            if (button_check == 4)
            {
                ironDoor = GameObject.Find("Jail_Door_Left");
                ironDoor.transform.gameObject.tag = "Interactive";
                Debug.Log("t'as réussi l'énigme");
            }
        }
    }
}
