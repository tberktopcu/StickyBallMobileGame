using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject boundry;
    public GameObject ground;
    public GameObject healthline;

    float updateSpeed = 0.2f;
    float health;
    float temp;


    Material boundryHealthLevel_mat;
    Material healthLine_mat;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        temp = health;
        
        boundryHealthLevel_mat = boundry.GetComponent<Renderer>().material;
        healthLine_mat = healthline.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (temp <= 0)
        {
            GAMEMANAGER.singleton.Reset();
        }

        temp = Mathf.MoveTowards(temp, health, updateSpeed * Time.deltaTime);
        boundryHealthLevel_mat.SetFloat("_HealthLevel", temp);
        ground.transform.localScale = new Vector3(ground.transform.localScale.x, ground.transform.localScale.y, temp);
    }

    public void UpdateHealthBarValue(float value)
    {
        temp = health;
        health += value/100;

    }

    public void ResetHealthBar()
    {
        health = 1;
    }

    public void UpdateHealthBarColor(Color color)
    {
        boundry.GetComponent<Renderer>().material.SetColor("_HealthColor", color * 10);
        healthLine_mat.SetColor("Color_480af1f6a5004a33a613be03705f45b4", color * 5.416924f);
    }
}
