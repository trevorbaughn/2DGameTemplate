using UnityEngine;

namespace Controllers
{
    public abstract class Controller : MonoBehaviour
    {
        public Pawn pawn;
    
        // Start is called before the first frame update
        protected virtual void Start()
        {
            //remember to attach controller to pawn
            gameObject.GetComponent<Pawn>().controller = this;
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if(pawn != null)
            {
                MakeDecisions();
            }
        }
    
        protected abstract void MakeDecisions();

    }
}
