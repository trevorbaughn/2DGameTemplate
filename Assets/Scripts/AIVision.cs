using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class AIVision : MonoBehaviour
{
    public List<PlayerController> playersInSight;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersInSight.Add(collision.gameObject.GetComponent<PlayerController>());
            
            EventManager.instance.aisCanSeePlayer.Add(this.GetComponentInParent<AIController>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playersInSight.Contains((collision.gameObject.GetComponent<PlayerController>())))
        {
            playersInSight.Remove(collision.gameObject.GetComponent<PlayerController>());
            
            EventManager.instance.aisCanSeePlayer.Remove(this.GetComponentInParent<AIController>());
        }
    }
}
