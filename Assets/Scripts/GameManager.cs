using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPause;
    [SerializeField] private static TextMeshProUGUI chronometer;
    [SerializeField] private static Canvas endScreen;

    private static int minutes;
    private static int seconds;
    private static int centiseconds;

    // Start is called before the first frame update
    void Start()
    {
        endScreen = transform.GetChild(0).GetComponent<Canvas>();
        print(endScreen.transform.GetChild(1).name);
        chronometer = endScreen.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPause)
        {
            centiseconds += (int)(Time.deltaTime /60 * 100);
            if (centiseconds >= 100)
            {
                centiseconds -= 100;
                seconds++;

                if (seconds >= 60)
                {
                    seconds -= 60;
                    minutes++;
                }
            }
        }
        print(GetFormattedTime());
    }

    public void ResetTime()
    {
        centiseconds = 0;
        seconds = 0;
        minutes = 0;
    }

    public static string GetFormattedTime()
    {
        return string.Format("{0:D2}:{1:D2}:{2:D2}", minutes, seconds, centiseconds);
    }

    public void SetPause()
    {
        isPause =!isPause;
    }

    public static void EndOfTheGame()
    {
        endScreen.gameObject.SetActive(true);
        chronometer.text = "You Lose !!!\n"+GetFormattedTime();
    }
}
