using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    [Header("Move Speeds")]
    public float maxMoveSpeed;
    public float baseMoveSpeed;
    public float moveSpeed;
}
