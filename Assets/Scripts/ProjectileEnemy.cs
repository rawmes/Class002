using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : Projectile
{
    
    public float bulletDamage;

    





    void OnEnable()
    {
        Invoke("KillMe", 1.5f);
    }




    void OnTriggerEnter2D(Collider2D col)
    {

       
        if (col.gameObject.tag != "Boss" && col.gameObject.tag != "Projectile" && col.gameObject.tag != "Enemy" && col.gameObject.tag !="Boundary")
        {
            
            if (col.gameObject.tag != "Player")
            {
                Destroy(col.gameObject);
            }
            else
            {
                col.GetComponent<PlayerControls>().Ouchie(bulletDamage);
            }

            KillMe();

        }
        if (col.gameObject.tag == "Boundary")
        {
            KillMe();

        }

    }
   
    void KillMe()
    {
        if (pooled)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
