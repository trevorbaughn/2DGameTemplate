using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public abstract class AIController : Controller
{
    public enum AIStates {Idle, Watch, WatchAndShoot, TellFriend};
    [SerializeField] protected AIStates currentState;
    protected float timeEnteredCurrentState;
    
    protected NPCPawn Pawn;
    public Emoter emoter;
    private OpinionHolder _impression;

    public GameObject target;
    [SerializeField] private float rotationOffset;
    
    // Start is called before the first frame update
    protected new virtual void Start()
    {
        base.Start();
        
        //add itself to list of ais
        GameManager.instance.ais.Add(this);

        Pawn = GetComponent<NPCPawn>();
        emoter = GetComponentInChildren<Emoter>();
        _impression = GetComponent<OpinionHolder>();
    }

    protected override void Update()
    {
        base.Update();

        
        if (_impression.ImpressionOfPlayer() > 0)
        { 
            emoter.ChangeEmoteState(Emoter.EmoteStates.Happy);
        }
        else if (_impression.ImpressionOfPlayer() == 0)
        {
            emoter.ChangeEmoteState(Emoter.EmoteStates.Neutral);
        }
        else if (_impression.ImpressionOfPlayer() < 0)
        {
            emoter.ChangeEmoteState(Emoter.EmoteStates.Sad);
        }
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


    public void RotateTowards(Vector3 target)
    {
        target.z = 0f;

        Vector3 objectPos = transform.position;
        target.x = target.x - objectPos.x;
        target.y = target.y - objectPos.y;

        float angle = (Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg)+90+rotationOffset;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    
}
