using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : PlayerController
{
    #region KeyCodes
    [Header("Control Key Codes")]
    [SerializeField] private KeyCode moveUp;
    [SerializeField] private KeyCode moveDown;
    [SerializeField] private KeyCode moveLeft;
    [SerializeField] private KeyCode moveRight;
    [SerializeField] private KeyCode shoot;

    //debugging keys
    [SerializeField] private KeyCode responsibilityUp;
    [SerializeField] private KeyCode responsibilityDown;
    #endregion KeyCodes

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void ProcessInputs()
    {
        if (Input.GetKey(moveUp))
        {
            pawn.MoveUp();
        }

        if (Input.GetKey(moveDown))
        {
            pawn.MoveDown();
        }

        if (Input.GetKey(moveLeft))
        {
            pawn.MoveLeft();
        }

        if (Input.GetKey(moveRight))
        {
            pawn.MoveRight();
        }

        if (Input.GetKeyDown(shoot))
        {
            pawn.Shoot();
        }

        //debug keys

        if (Input.GetKeyDown(responsibilityUp))
        {
            pawn.GetComponent<Responsibility>().current += 5;
        }

        if (Input.GetKeyDown(responsibilityDown))
        {
            pawn.GetComponent<Responsibility>().current -= 5;
        }
    }
}
