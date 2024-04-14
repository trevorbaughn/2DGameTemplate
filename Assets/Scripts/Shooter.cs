using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    #region Variables

    public float timeBetweenShots;
    public float shootForce;
    public BulletManager bulletManager;

    private Vector3 _mousePos;
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
        GameObject bullet = bulletManager.GetBullet(shootPoint.position,
                                        transform.rotation);

        //send it data from Bullet component
        Bullet projectile = bullet.GetComponent<Bullet>();

        //make sure projectile exists
        if(projectile != null)
        {
            //then give it properties
            projectile.owner = shooter;
            projectile.bm = bulletManager;
        }

        //push it at force
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            AIController aiController = GetComponent<AIController>();
            if (aiController != null)
            {
                bulletRb.AddForce(-(this.transform.position - aiController.target.transform.position).normalized * shootForce);
            }
            else
            {
                bulletRb.AddForce(-(this.transform.position - _mousePos).normalized * shootForce);
            }
            
        }
    }

    private void Update()
    {
        //rotation
        _mousePos = Input.mousePosition;
        _mousePos.z = 0;
     
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        _mousePos.x = _mousePos.x - objectPos.x;
        _mousePos.y = _mousePos.y - objectPos.y;
    }
}
