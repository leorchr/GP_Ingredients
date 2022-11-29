using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElevatorCodeVerification : MonoBehaviour
{
    public int realNumber1, realNumber2, realNumber3, realNumber4;
    public TMP_Text number1, number2, number3, number4;

    public bool goodNumber1, goodNumber2, goodNumber3, goodNumber4;
    public Animator harrow;

    public void Update()
    {
        int.TryParse(number1.GetParsedText(), out realNumber1);
        int.TryParse(number2.GetParsedText(), out realNumber2);
        int.TryParse(number3.GetParsedText(), out realNumber3);
        int.TryParse(number4.GetParsedText(), out realNumber4);

        goodCode();
    }

    public void goodCode()
    {
        if(realNumber1 == 8)
        {
            goodNumber1 = true;
        }

        if (realNumber2 == 6)
        {
            goodNumber2 = true;
        }

        if (realNumber3 == 5)
        {
            goodNumber3 = true;
        }

        if (realNumber4 == 3)
        {
            goodNumber4 = true;
        }

        if(goodNumber1 && goodNumber2 && goodNumber3 && goodNumber4)
        {
            Debug.Log("Trouvé !");
            harrow.SetBool("OpeningOfTheHarrow", true);
        }
    }
}
