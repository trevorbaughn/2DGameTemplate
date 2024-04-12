using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    //take damage
    public void TakeDamage(float amount)
    {
        //take the damage
        currentHealth -= amount;

        //TODO: play hitsound

        //if you have less than 0 health you die
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    //heal
    public void Heal(float amount)
    {
        //heal
        currentHealth += amount;

        //clamp health at max
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    //die
    //all it does is destroy the object rn
    public void Die()
    {
        this.gameObject.SetActive(false);
       
        //TODO: play death sound

        //if it is a player, go to game over state
        if(this.CompareTag("Player"))
        {
            GameManager.instance.ActivateGameOverState();
        }
    }


}