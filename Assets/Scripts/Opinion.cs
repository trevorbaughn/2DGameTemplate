using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opinion
{
    public string name;
    public float responsibilityWeight;
    
    public Opinion(string eventName, float responsibilityToAdd)
    {
        responsibilityWeight = responsibilityToAdd;
        name = eventName;
    }
}
