using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    #region Variables
    //static (stays same) quest manager instance
    public static BulletManager instance;

    public List<GameObject> pool;
    public int numOfBullets;
    public GameObject prefab;
    #endregion Variables

    //Awake is called before Start
    private void Awake()
    {
        if (instance == null)
        {
            //this is THE bullet manager
            instance = this;
            //don't kill it in a new scene.
            DontDestroyOnLoad(gameObject);
        }
        else //this isn't THE bullet manager
        {
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Gets bullet from inactive bullets or creates one if there aren't any
    /// </summary>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    public GameObject GetBullet(Vector3 position, Quaternion rotation)
    {
        //find inactive GameObject
        foreach(GameObject bullet in pool)
        {
            if (!bullet.activeInHierarchy)
            {
                //set values
                Transform bulletTransform = bullet.GetComponent<Transform>();
                bulletTransform.position = position;
                bulletTransform.rotation = rotation;

                
                bullet.GetComponent<Bullet>().ResetTimer();


                //activate
                bullet.SetActive(true);

                return bullet;
            }
        }

        //if none already exist inactive, make a new one and add it to the pool
        GameObject bulletObj = Instantiate(prefab, position, rotation);
        pool.Add(bulletObj);
        bulletObj.name = "Bullet " + pool.Count;
        bulletObj.transform.parent = this.transform;
        bulletObj.GetComponent<Bullet>().bm = this;
        return bulletObj;
    }


}
