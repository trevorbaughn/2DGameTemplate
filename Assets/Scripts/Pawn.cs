using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Controller controller;
    
    [Header("Move Speeds")]
    public float maxMoveSpeed;
    public float baseMoveSpeed;
    public float moveSpeed;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        //remember to attach controller to pawn
        gameObject.GetComponent<Controller>().pawn = this;
    }
}
