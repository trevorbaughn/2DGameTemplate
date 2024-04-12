using UnityEngine;

namespace Controllers
{
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



        protected override void MakeDecisions()
        {
            if (Input.GetKey(moveUp))
            {
                Pawn.MoveUp();
            }

            if (Input.GetKey(moveDown))
            {
                Pawn.MoveDown();
            }

            if (Input.GetKey(moveLeft))
            {
                Pawn.MoveLeft();
            }

            if (Input.GetKey(moveRight))
            {
                Pawn.MoveRight();
            }

            if (Input.GetKeyDown(shoot))
            {
                Pawn.Shoot();
            }

            //debug keys

            if (Input.GetKeyDown(responsibilityUp))
            {
                Pawn.GetComponent<Responsibility>().current += 5;
            }

            if (Input.GetKeyDown(responsibilityDown))
            {
                Pawn.GetComponent<Responsibility>().current -= 5;
            }
        }
    }
}
