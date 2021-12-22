using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public KeyCode PinkKey;
    public KeyCode BlueKey;
    public KeyCode PurpleKey;

    void Update()
    {
        if(Input.GetKeyDown(PinkKey))
        {
            GetComponent<PlayerController>().ButtonPressed("Pink");
        }
        else if (Input.GetKeyDown(BlueKey))
        {
            GetComponent<PlayerController>().ButtonPressed("Blue");
        }
        else if (Input.GetKeyDown(PurpleKey))
        {
            GetComponent<PlayerController>().ButtonPressed("Purple");
        }
    }
}
