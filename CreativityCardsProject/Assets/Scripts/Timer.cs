using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeLeft; //Seconds Overall
    public Text countdown; //UI Text Object
    public GameObject gameOverPanel;
    public GameObject mainUI;
    public GameObject player;

    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }
    void Update()
    {
        countdown.text = ("" + timeLeft); //Showing the Score on the Canvas
        if (timeLeft <= -0)
        {
            StopCoroutine("LoseTime");
            mainUI.SetActive(false);
            gameOverPanel.SetActive(true);
            Destroy(player);
            Cursor.visible = true;
        }
    }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
