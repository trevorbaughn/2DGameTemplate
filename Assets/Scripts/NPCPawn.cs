using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPawn : Pawn, IKillable
{
    public Health health;

    private PlayerMover mover;
    
    protected override void Start()
    {
        base.Start();
        
        health = GetComponent<Health>();
        
        mover = GetComponent<PlayerMover>();
    }

    public void SayText()
    {
        
    }

    public void MoveForward()
    {
        //use the mover to move forward if not null
        if (mover != null)
        {
            mover.MoveForward(-moveSpeed);
        }
    }

    /// <summary>
    /// Unloads the player pawn, to be loaded again later.  "Fakes" death to prevent needing to redo
    /// things too heavily later.  Just some data change stuff.
    /// </summary>
    public void Die()
    {
        this.gameObject.SetActive(false);
    }
}