using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    
    public List<OpinionHolder> opinionHoldersCanSeePlayer;
    
    //Awake is called before Start
    private void Awake()
    {
        if (instance == null)
        {
            //this is THE game manager
            instance = this;
            //don't kill it in a new scene.
            DontDestroyOnLoad(gameObject);
        }
        else //this isn't THE game manager
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }

    public void FormImpressions(string eventName, float responsibilityWeight)
    {
        
        foreach (OpinionHolder opinionHolder in opinionHoldersCanSeePlayer)
        {
            opinionHolder.CreateOpinion(eventName, responsibilityWeight);
            Debug.Log("Form Impressions: " + opinionHolder.name);
        }
    }
    
    
}
