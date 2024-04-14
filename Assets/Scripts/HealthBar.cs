using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthImage;
    public Health health;

    // Update is called once per frame
    void Update()
    {
        //never do this again, THIS IS A PROTOTYPE
        healthImage.fillAmount = health.currentHealth / health.maxHealth ;
    }
}
