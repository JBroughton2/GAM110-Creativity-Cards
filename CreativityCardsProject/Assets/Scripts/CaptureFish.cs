using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureFish : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "BlackFish")
        {
            ScoreScript.scoreValue += 10;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "RedFish")
        {
            ScoreScript.scoreValue += 5;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "YellowFish")
        {
            ScoreScript.scoreValue += 1;
            Destroy(col.gameObject);
        }
    }

}

