using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emoter : MonoBehaviour
{
    public enum EmoteStates
    {
        Sad,
        Neutral,
        Happy
    };

    public EmoteStates currentEmote = EmoteStates.Neutral;

    [SerializeField] private GameObject sadface;
    [SerializeField] private GameObject neutralface;
    [SerializeField] private GameObject happyface;

    // Update is called once per frame
    void Update()
    {



        DisableAllFaces();
        switch (currentEmote)
        {
            case EmoteStates.Sad:
                sadface.SetActive(true);
                break;
            case EmoteStates.Neutral:
                neutralface.SetActive(true);
                break;
            case EmoteStates.Happy:
                happyface.SetActive(true);
                break;
        }
    }

    private void DisableAllFaces()
    {
        sadface.SetActive(false);
        neutralface.SetActive(false);
        happyface.SetActive(false);
    }

    public void ChangeEmoteState(EmoteStates emoteState)
    {
        currentEmote = emoteState;
    }

}
