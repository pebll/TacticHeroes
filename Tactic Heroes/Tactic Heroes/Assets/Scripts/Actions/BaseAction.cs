using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAction : MonoBehaviour
{
    public int Lenght { get; private set; }
    public string Name { get; private set; }
    public string Type { get; private set; }

    public void Execute()
    {
        Debug.Log("Action " + Name + "used");
    }

}
