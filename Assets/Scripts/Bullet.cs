using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IKillable
{
    #region Variables
    public BulletManager bm; //manager
    public Pawn owner; //who shot it
    [SerializeField] private float damage;
    private float timeToUnload; //time until unload
    [SerializeField] private BulletData bulletData; //data of the bullet.  Such as start time for death.
    #endregion Variables

    private void Start()
    {
        //load scriptable object from resources
        bulletData = Resources.Load<BulletData>("ScriptableObjects/BulletData");

        timeToUnload = bulletData.startTimerAt;
    }

    //when this enters another object, run
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("Hellotest");
        other.GetComponent<Health>().TakeDamage(damage);
        
        //unload self
        Die();
    }

    private void Update()
    {
        //time until unloads
        timeToUnload -= Time.deltaTime;
        if(timeToUnload <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Destroy and remove from list if bigger than pool size, otherwise just set inactive
    /// </summary>
    public void Die()
    {
        if (bm.pool.Count > bm.numOfBullets)
        {
            BulletManager.instance.pool.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void ResetTimer()
    {
        timeToUnload = bulletData.startTimerAt;
    }


}
