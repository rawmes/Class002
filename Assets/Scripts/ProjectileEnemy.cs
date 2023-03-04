using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public GameObject shoot_effect;
    public GameObject hit_effect;
    public float bulletDamage = 5f;





    void Start()
    {
        //GameObject obj = (GameObject)Instantiate(shoot_effect, transform.position - new Vector3(0, 0, 5), Quaternion.identity); //Spawn muzzle flash
        //obj.transform.parent = firing_ship.transform;
        Destroy(gameObject, 1.2f);
        
    }




    void OnTriggerEnter2D(Collider2D col)
    {

        //Don't want to collide with the ship that's shooting this thing, nor another projectile.
        if (col.gameObject.tag != "Boss" && col.gameObject.tag != "Projectile" && col.gameObject.tag != "Enemy" && col.gameObject.tag !="Boundary")
        {
            //Instantiate(hit_effect, transform.position, Quaternion.identity);
            if (col.gameObject.tag != "Player")
            {
                Destroy(col.gameObject);
            }
            else
            {
                col.GetComponent<PlayerControls>().Ouchie(bulletDamage);
            }

            Destroy(gameObject);

        }
        if (col.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);

        }

    }


}
