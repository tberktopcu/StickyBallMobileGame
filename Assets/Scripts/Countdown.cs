using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    TMP_Text countdown;
    float totalseconds = 10;
    float decrement = .25f;
    float waitBeforeReset = 7;
    float minutes;
    float digit1;
    float digit2;

    // Start is called before the first frame update
    void Start()
    {
        countdown = GetComponent<TextMeshPro>();
        InvokeRepeating("Counting", 0, decrement);
    }
    void Counting()
    {
        Timer();
    }
    void Timer()
    {
        if (totalseconds != 0)
        {
            countdown.text = Mathf.Floor(minutes).ToString() + "\n" + colon + "\n" + Mathf.Floor(digit1).ToString() + "\n" + Mathf.Floor(digit2).ToString();
            totalseconds = totalseconds - decrement;
            minutes = totalseconds / 60;
            digit1 = (totalseconds % 60) / 10;
            digit2 = (totalseconds % 60) % 10;
            Blink();
        }
        else
        {
            countdown.text = "love";
            Invoke("Reset", waitBeforeReset);
        }
    }
    void Reset()
    {
        if (totalseconds == 0)
        {
            totalseconds = totalseconds + 10;
            CancelInvoke();
            InvokeRepeating("Counting", 0, decrement);
        }
    }
    string colon;
    void Blink()
    {
        if (totalseconds % .5 == 0)
        {
            colon = ":";
        }
        else colon = " ";
    }
}
