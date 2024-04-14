using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    public class AIWitnessController : AIController
    {
        [SerializeField] private AIController friend;
        [SerializeField] private float timeToMoveToFriend;

        private AIVision _vision;
        private OpinionHolder opinionHolder;
        
        // Start is called before the first frame update
         protected override void Start()
        {
            base.Start();

            _vision = GetComponentInChildren<AIVision>();
        
            ChangeState(AIStates.Idle);

            opinionHolder = GetComponent<OpinionHolder>();
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

                    if (_vision.sightableObjectsInSight.Contains(friend.gameObject))
                    {
                        ChangeState(AIStates.TellFriend);
                    }
                    break;
                case AIStates.TellFriend:
                    DoTellFriendState();

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

        private void DoTellFriendState()
        {
            RotateTowards(friend.transform.position);
            
            if (Vector3.Distance(transform.position, friend.transform.position) > 2)
                this.Pawn.MoveForward();
            
            Opinion opinionToGive = opinionHolder.Impressions[Random.Range(0, opinionHolder.Impressions.Count)];

            OpinionHolder friendOpinionHolder = friend.GetComponent<OpinionHolder>();
            foreach (Opinion opinion in friendOpinionHolder.Impressions)
            {
                if (opinion.name == opinionToGive.name)
                {
                    return;
                }
            }
            opinionHolder.GiveOpinion(friend.GetComponent<OpinionHolder>(), opinionToGive);
        }
    }
}
