using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuffixController : MonoBehaviour
{
    public GameObject rank;
    public GameObject suffix;
    TMP_Text rankTMP;
    TMP_Text suffixTMP;


    // Start is called before the first frame update
    void Start()
    {
        rankTMP = rank.GetComponent<TextMeshPro>();
        suffixTMP = suffix.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (rankTMP.text.Substring(rankTMP.text.Length - 1))
        {
            case "0":
                suffixTMP.text = "th";
                break;
            case "1":
                suffixTMP.text = "st";
                break;
            case "2":
                suffixTMP.text = "nd";
                break;
            case "3":
                suffixTMP.text = "rd";
                break;
            case "4":
                suffixTMP.text = "th";
                break;
            case "5":
                suffixTMP.text = "th";
                break;
            case "6":
                suffixTMP.text = "th";
                break;
            case "7":
                suffixTMP.text = "th";
                break;
            case "8":
                suffixTMP.text = "th";
                break;
            case "9":
                suffixTMP.text = "th";
                break;
        }
    }
}
