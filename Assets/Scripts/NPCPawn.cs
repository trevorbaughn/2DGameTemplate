using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPawn : Pawn, IKillable
{
    public Health health;
    
    private void Start()
    {
        health = GetComponent<Health>();
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