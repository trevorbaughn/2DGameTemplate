using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(PlayerPawn))]
    public abstract class PlayerController : Controller
    {
        protected PlayerPawn Pawn;
        public int controllerID;

        // Start is called before the first frame update
        protected new virtual void Start()
        {
            base.Start();
        
            //add itself to list of players
            GameManager.instance.players.Add(this);

            Pawn = GetComponent<PlayerPawn>();
        }
        protected virtual void OnDestroy()
        {
            //remove itself from list of players
            GameManager.instance.players.Remove(this);
        }



    }
}
