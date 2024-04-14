using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpinionHolder : MonoBehaviour
{
    [SerializeField] private bool isGood = true;

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
        if (!isGood)
        {
            objectiveResponsibility *= -1;
        }
        Impressions.Add(new Opinion(eventName, objectiveResponsibility));
    }

    public void GiveOpinion(OpinionHolder toGiveTo, Opinion toGive)
    {
        toGiveTo.CreateOpinion(toGive.name, toGive.responsibilityWeight);
    }

    
}
