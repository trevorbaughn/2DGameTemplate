using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    #region Variables
    public float timeBetweenShots;
    public float shootForce;
    #endregion Variables

    /// <summary>
    /// Shoots a bullet from a point at a force
    /// </summary>
    /// <param name="bulletPrefab"></param>
    /// <param name="shootForce"></param>
    /// <param name="damageDone"></param>
    /// <param name="shooter"></param>
    /// <param name="shootPoint"></param>
    public void Shoot(GameObject bulletPrefab, float shootForce, Pawn shooter, Transform shootPoint)
    {
        //create bullet
        GameObject bullet = BulletManager.instance.GetBullet(shootPoint.position,
                                        transform.rotation);

        //send it data from Bullet component
        Bullet projectile = bullet.GetComponent<Bullet>();

        //make sure projectile exists
        if(projectile != null)
        {
            //then give it properties
            projectile.owner = shooter;
            projectile.bm = BulletManager.instance;
        }

        //push it at force
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            bulletRb.AddForce(transform.up * shootForce);
        }
    }
}
