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

            TargetPosition = this.transform.position;
        }

        protected override void MakeDecisions()
        {
            if (pawn == null) return;

            switch (currentState)
            {
                case AIStates.Idle:
                    DoIdleState();
                    break;
            }
        }

        private void DoIdleState()
        {
            //do nothing
        }
    }
}
