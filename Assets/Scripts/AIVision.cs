using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class AIVision : MonoBehaviour
{
    public List<PlayerController> playersInSight;

    public List<GameObject> sightableObjectsInSight;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersInSight.Add(collision.gameObject.GetComponent<PlayerController>());
            
            EventManager.instance.opinionHoldersCanSeePlayer.Add(this.GetComponentInParent<OpinionHolder>());
        }

        if (collision.CompareTag("Sightable"))
        {
            sightableObjectsInSight.Add(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playersInSight.Contains((collision.gameObject.GetComponent<PlayerController>())))
        {
            playersInSight.Remove(collision.gameObject.GetComponent<PlayerController>());
            
            EventManager.instance.opinionHoldersCanSeePlayer.Remove(this.GetComponentInParent<OpinionHolder>());
        }
        
        if (sightableObjectsInSight.Contains(collision.gameObject))
        {
            sightableObjectsInSight.Remove(collision.gameObject);
        }
    }
}
