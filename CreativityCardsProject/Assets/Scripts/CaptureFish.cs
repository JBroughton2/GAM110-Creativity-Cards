using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureFish : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Fish")
        {
            Destroy(col.gameObject);
        }
    }

}

