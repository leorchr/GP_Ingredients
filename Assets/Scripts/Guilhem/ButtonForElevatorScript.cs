using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForElevatorScript : Interactive
{
    public GameObject elevatorCode;
    public bool active;
    public GameObject interactiveUI;

    public bool verif = false;

    public override void OnInteraction()
    {
        elevatorCode.SetActive(true);
        active = true;

        interactiveUI.SetActive(false);
    }
}
