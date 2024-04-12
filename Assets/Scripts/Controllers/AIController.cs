using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public abstract class AIController : Controller
{
    public enum AIStates {Idle, Chase};
    [SerializeField] protected AIStates currentState;
    protected float timeEnteredCurrentState;

    protected Vector3 TargetPosition;

    // Start is called before the first frame update
    protected new virtual void Start()
    {
        base.Start();
        
        //add itself to list of ais
        GameManager.instance.ais.Add(this);
    }
    protected void OnDestroy()
    {
        //remove itself from list of players
        GameManager.instance.ais.Remove(this);
    }

    public virtual void ChangeState(AIStates newState)
    {
        //remember change state time
        timeEnteredCurrentState = Time.time;
        //change state
        currentState = newState;
    }

    public virtual bool IsTimePassed(float amountOfTime)
    {
        if (Time.time - timeEnteredCurrentState >= amountOfTime)
        {
            return true;
        }
        return false;
    }

    public virtual PlayerController CanSeePlayer(PlayerController player)
    {
        return this.GetComponentInChildren<AIVision>().playersInSight[0];
    }
}
