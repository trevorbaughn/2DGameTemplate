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
        StartCoroutine(Shake(0.15f));

        //TODO: play hitsound

        //if you have less than 0 health you die
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }
    
    IEnumerator Shake(float amount) {
        for ( int i = 0; i < 2; i++)
        {
            transform.localPosition += new Vector3(amount, 0, 0);
            yield return new WaitForSeconds(0.05f);
            transform.localPosition -= new Vector3(amount, 0, 0);
            yield return new WaitForSeconds(0.05f);
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