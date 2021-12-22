using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public string BlockColor;

    public void BlockDestroy()
    {
        Destroy(gameObject);
    }
}
