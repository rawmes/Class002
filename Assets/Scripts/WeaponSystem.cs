using SmallShips;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] GameObject[] barrels;
    [SerializeField] GameObject bullet;
    [SerializeField] float forceValue;
    [SerializeField] public bool activated;
    
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
}
