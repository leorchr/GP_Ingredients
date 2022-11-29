using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryText : MonoBehaviour
{
    public GameObject victory;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            victory.SetActive(true);
        }
    }
}
