using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    public class AIBullyController : AIController
    {
        [SerializeField] private Transform shootPoint;
        private Shooter shooter;
        
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            shooter = this.GetComponent<Shooter>();
            ChangeState(AIStates.Idle);
        }

        protected override void MakeDecisions()
        {
            if (pawn == null) return;

            switch (currentState)
            {
                case AIStates.Idle:
                    DoIdleState();

                    if (IsTimePassed(1))
                    {
                        ChangeState(AIStates.WatchAndShoot);
                    }
                    break;
                case AIStates.WatchAndShoot:
                    DoWatchAndShootState();

                    if (target.GetComponent<Health>().currentHealth <= 0)
                    {
                        target = GameManager.instance.players[0].gameObject;
                    }
                    break;
            }
        }

        private void DoIdleState()
        {
            //do nothing
        }

        private void DoWatchAndShootState()
        {
            RotateTowards(target.transform.position);

            if (IsTimePassed(1)) //change state to reset timer to make this easy, don't normally do this ;-;
            {
                shooter.Shoot(shooter.bulletManager.prefab, shooter.shootForce, this.pawn, shootPoint.transform);
                ChangeState(AIStates.WatchAndShoot);
            }
        }
    }
}