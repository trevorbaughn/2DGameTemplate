using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerPawn))]
public abstract class PlayerController : MonoBehaviour
{
    protected PlayerPawn pawn;
    public int controllerID;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //add itself to list of players
        GameManager.instance.players.Add(this);

        pawn = GetComponent<PlayerPawn>();
    }
    protected virtual void OnDestroy()
    {
        //remove itself from list of players
        GameManager.instance.players.Remove(this);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(pawn != null)
        {
            ProcessInputs();
        }
    }

    protected abstract void ProcessInputs();
}
