using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ResponsibilityBar : MonoBehaviour
{
    private Image responsibilityImage;
    public Responsibility responsibility;

    private void Start()
    {
        responsibilityImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        responsibilityImage.fillAmount = responsibility.animated / responsibility.max;
    }
}
