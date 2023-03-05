using SmallShips;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] GameObject[] barrels;
    [SerializeField] GameObject bullet;
    [SerializeField] public float forceValue;
    [SerializeField] public bool activated;
    [SerializeField] public int maxBullet; //max number of bullet
    public int count;  // counting the list of bullet 

    
    public void MakeBullet()
    {
        for (int i = 0; i < maxBullet; i++)
        {
            GameObject currenetBullet =Instantiate(bullet);
            Projectile bsc = currenetBullet.GetComponent<Projectile>();
            bsc.pooled = true;
            gameObjects.Add(currenetBullet);
            



        }
    }
    public void Fire()
    {
        foreach(GameObject barrel in barrels)
        {
            GameObject currentBullet = Instantiate(bullet,barrel.transform.position,Quaternion.identity);
            Rigidbody2D currentRb = currentBullet.GetComponent<Rigidbody2D>();
            currentRb.velocity = new Vector2(0f,-forceValue);
            Color color = new Color(
                    (float)Random.Range(0, 255),
                    (float)Random.Range(0, 255),
                    (float)Random.Range(0, 255));

            currentBullet.GetComponent<SpriteRenderer>().color = color;
        }
    }

    public void FirePool()
    {
     
        if(count >= maxBullet) count = 0;
        foreach(GameObject barrel in barrels)
        {
            gameObjects[count].SetActive(true);
            gameObjects[count].transform.position = barrel.transform.position;
            gameObjects[count].GetComponent<Rigidbody2D>().velocity = new Vector2(0f,-forceValue);

            count++;
        }
        
    }
}
