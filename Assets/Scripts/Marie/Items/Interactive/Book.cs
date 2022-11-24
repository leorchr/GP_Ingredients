using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Interactive
{
    public GameObject bookStory;
    public bool active;
    public GameObject interactiveUI;

    public bool verif = false;

    public override void OnInteraction()
    {
        bookStory.SetActive(true);
        active = true;

        interactiveUI.SetActive(false);

        //FindObjectOfType<PlayerInteractionAnim>().StoryBook();


    }
}
