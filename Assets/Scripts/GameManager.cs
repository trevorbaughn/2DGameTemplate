using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    //static (stays same) game manager instance
    public static GameManager instance;
    public static AudioManager audioManager;
    public static EventManager eventManager;

    [Header("Lists")]
    public List<PlayerController> players;
    public List<AIController> ais;


    [Header("Screen State Objects")]
    [SerializeField] private GameObject titleScreenStateObject;
    [SerializeField] private GameObject gameOverStateObject;
    [SerializeField] private GameObject mainMenuStateObject;
    [SerializeField] private GameObject optionsStateObject;
    [SerializeField] private GameObject controlsStateObject;
    [SerializeField] private GameObject creditsGameObject;
    [SerializeField] private GameObject gameplayStateObject;


    //Awake is called before Start
    private void Awake()
    {
        if (instance == null)
        {
            //this is THE game manager
            instance = this;
            //don't kill it in a new scene.
            DontDestroyOnLoad(gameObject);
        }
        else //this isn't THE game manager
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ActivateTitleScreenState();

        //attach audiomanager to gamemanager
        audioManager = AudioManager.instance;
        
        eventManager = EventManager.instance;
    }

    //deactivate all gamestates
    private void DeactivateAllStates()
    {
        titleScreenStateObject.SetActive(false);
        gameOverStateObject.SetActive(false);
        mainMenuStateObject.SetActive(false);
        optionsStateObject.SetActive(false);
        gameplayStateObject.SetActive(false);
        controlsStateObject.SetActive(false);
        creditsGameObject.SetActive(false);
    }

    public void ActivateTitleScreenState()
    {
        DeactivateAllStates();
        titleScreenStateObject.SetActive(true);
    }

    public void ActivateGameOverState()
    {
        DeactivateAllStates();
        gameOverStateObject.SetActive(true);
    }

    public void ActivateMainMenuState()
    {
        DeactivateAllStates();
        mainMenuStateObject.SetActive(true);
        
        ActivateGameplayState(); //temp; there is no main menu
    }

    public void ActivateOptionsState()
    {
        DeactivateAllStates();
        optionsStateObject.SetActive(true);
    }

    public void ActivateControlsState()
    {
        DeactivateAllStates();
        controlsStateObject.SetActive(true);
    }

    public void ActivateCreditsState()
    {
        DeactivateAllStates();
        creditsGameObject.SetActive(true);
    }

    public void ActivateGameplayState()
    {
        DeactivateAllStates();
        gameplayStateObject.SetActive(true);
        ResetGame();
    }

    /// <summary>
    /// resets game
    /// NOTE: currently only reorders players
    /// </summary>
    private void ResetGame()
    {
        Utils.Player playerUtils = new Utils.Player();
        playerUtils.Reorder();
    }

}


//game utilities that aren't necessarily managed data, but should be accessible by anything
namespace Utils
{
    //player-related utilities
    public class Player
    {
        /// <summary>
        /// return a list of players using a keyboard
        /// </summary>
        /// <returns></returns>
        public List<KeyboardController> GetKeyboardPlayers()
        {
            return new List<KeyboardController> (GameManager.instance.players.OfType<KeyboardController>()).ToList();
        }

        /// <summary>
        /// reorder player list by controllerID to keep consistent with list index
        /// for fast "id"
        /// </summary>
        public void Reorder()
        {
            GameManager.instance.players = (from player in GameManager.instance.players
                       orderby player.controllerID descending select player).ToList();
        }

        //if specific player exists
        public bool Exists(int idToFind)
        {
            return GameManager.instance.players.Exists((PlayerController controller) => controller.controllerID == idToFind);
        }

        //overload for if any player exists
        public bool Exists()
        {
            if (GameManager.instance.players.Count > 0) return true;
            return false;
        }
    }
}