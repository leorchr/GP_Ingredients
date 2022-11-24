using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickable : MonoBehaviour
{
    public virtual void OnPick()
    {
        Debug.Log("programme stp");
    }
}
