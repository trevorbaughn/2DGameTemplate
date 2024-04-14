using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opinion : MonoBehaviour
{
    public new string name;
    public float responsibilityWeight;
    
    public Opinion(string eventName, float responsibilityToAdd)
    {
        responsibilityWeight = responsibilityToAdd;
        name = eventName;
    }
}
