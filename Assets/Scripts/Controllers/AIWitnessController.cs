using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    public class AIWitnessController : AIController
    {
        
        
        // Start is called before the first frame update
         protected override void Start()
        {
            base.Start();
        
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
                        ChangeState(AIStates.Watch);
                    }
                    break;
                case AIStates.Watch:
                    DoWatchState();
                    
                    break;
            }
        }

        private void DoIdleState()
        {
            //do nothing
        }

        private void DoWatchState()
        {
            RotateTowards(target.transform.position);
        }
    }
}
