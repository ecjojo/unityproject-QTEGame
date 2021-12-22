using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownScript : MonoBehaviour
{
    public AudioSource Clickssound;

    public void Go()
    {
        Clickssound.Play();
        GameControl.instance.GameStart();
    }
}
