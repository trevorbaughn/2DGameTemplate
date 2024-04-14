using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

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
        [SerializeField] private KeyCode toggleCameraMovement;
        
        [SerializeField] private KeyCode toggleVisionCones;
        [SerializeField] private KeyCode togglePaladinHat;
        [SerializeField] private KeyCode toggleThiefHat;
        [SerializeField] private KeyCode reset;
        #endregion KeyCodes

        private bool _isCameraMovementOn = true;
        [SerializeField] private GameObject _paladinHat;
        [SerializeField] private GameObject _thiefHat;
        [FormerlySerializedAs("marquit")] [SerializeField] private GameObject kevin;
        
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

            if (Input.GetKeyDown(toggleCameraMovement))
            {
                CameraController camera = FindObjectOfType<CameraController>();
                if (_isCameraMovementOn)
                {
                    camera.currentSpeed = camera.maxSpeed;
                }
                else
                {
                    camera.currentSpeed = 0;
                }

                _isCameraMovementOn = !_isCameraMovementOn;

            }

            if (Input.GetKeyDown((toggleVisionCones)))
            {
                foreach (GameObject cone in GameManager.instance.visionCones)
                {
                    if (cone.GetComponent<SpriteRenderer>().enabled == true)
                    {
                        cone.GetComponent<SpriteRenderer>().enabled = false;
                    }
                    else
                    {
                        cone.GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
            }
            
            if (Input.GetKeyDown((togglePaladinHat)))
            {
                _paladinHat.gameObject.SetActive(!_paladinHat.activeInHierarchy);
            }
            
            if (Input.GetKeyDown((toggleThiefHat)))
            {
                _thiefHat.gameObject.SetActive(!_thiefHat.activeInHierarchy);
            }

            if (Input.GetKeyDown(reset))
            {
                foreach (AIController aiController in GameManager.instance.ais)
                {
                    aiController.gameObject.SetActive(true);
                    
                    if (aiController.gameObject.name == "EvilKevinNPC")
                    {
                        AIBullyController aiBullyController = aiController.gameObject.GetComponent<AIBullyController>();

                        aiBullyController.target = kevin;
                        aiBullyController.ChangeState(AIController.AIStates.WatchAndShoot);
                    }
                    else
                    {
                        aiController.GetComponent<AIWitnessController>().ChangeState(AIController.AIStates.Watch);
                    }
                    
                    if (aiController.gameObject.name == "DerricNPC")
                    {
                        aiController.gameObject.transform.SetPositionAndRotation(new Vector3(6.8f, 4.5f, 0), Quaternion.Euler(0,0,0));
                        aiController.gameObject.GetComponent<AIWitnessController>().ChangeState(AIController.AIStates.Idle);
                    }
                        
                    
                    Health health = aiController.GetComponent<Health>();
                    health.currentHealth = health.maxHealth;
                    health.isDead = false;

                    OpinionHolder opinionHolder = aiController.GetComponent<OpinionHolder>();


                    foreach (Opinion opinion in opinionHolder.Impressions)
                    {
                        Destroy(opinion.gameObject);
                    }
                    opinionHolder.Impressions.Clear();
                    
                }

                PlayerController player = GameManager.instance.players[0];
                player.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
                player.gameObject.SetActive(true);
                
            }
        }
    }
}
