using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElevatorCodeScript : MonoBehaviour
{
    public int Number;

    public TextMeshProUGUI numberText;

    public void Update()
    {
        numberText.text = Number.ToString();
    }

    public void increaseNumber()
    {
        if(Number < 9)
        {
            Number++;
        }
    }

    public void decreaseNumber()
    {
        if (Number > 0)
        {
            Number -= 1;
        }
    }
}
