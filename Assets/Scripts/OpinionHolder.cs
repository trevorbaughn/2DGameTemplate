using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = System.Numerics.Vector3;

public class OpinionHolder : MonoBehaviour
{
    [SerializeField] private bool isGood = true;
    [SerializeField] private GameObject prefab;

    public List<Opinion> Impressions;

   

    public float ImpressionOfPlayer()
    {
        float impression = 0;
        foreach(Opinion opinion in Impressions)
        {
            impression += opinion.responsibilityWeight;
        }

        return impression;
    }

    public void CreateOpinion(string eventName, float objectiveResponsibility)
    {
        Debug.Log("Create Opinion: " + this.name + ", " + eventName + ", " + objectiveResponsibility);
        if (!isGood)
        {
            objectiveResponsibility *= -1;
        }
        
        GameObject impression = Instantiate(prefab, this.transform);
        Opinion opinion = impression.GetComponent<Opinion>();
        opinion.name = eventName;
        opinion.responsibilityWeight = objectiveResponsibility;
        Impressions.Add(opinion);
        impression.name = eventName;
        impression.transform.parent = this.transform;
    }

    public void GiveOpinion(OpinionHolder toGiveTo, Opinion toGive)
    {
        toGiveTo.CreateOpinion(toGive.name, toGive.responsibilityWeight);
    }

    
}
