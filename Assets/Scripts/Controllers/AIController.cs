using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : Controller
{
    public enum AIStates {};
    [SerializeField] protected AIStates currentState;
    protected float timeEnteredCurrentState;

    // Start is called before the first frame update
    protected override void Start()
    {
        //add itself to list of ais
        GameManager.instance.ais.Add(this);

        //remember to attach controller to pawn
        //gameObject.GetComponentInChildren<Pawn>().controller = this;
    }
    protected override void OnDestroy()
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
}
