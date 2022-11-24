using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactive
{
    public Animator animator;
    public override void OnInteraction()
    {
        Inventory.Instance.RemoveFromInventory(requiredItem);

        //start animation
        animator.SetBool("doorOpen", true);
    }
}
