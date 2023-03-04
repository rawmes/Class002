using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Projectile : MonoBehaviour {

	public float damage = 1f;
	public GameObject shoot_effect;
	public GameObject hit_effect;
	[SerializeField] public GameObject firing_ship;

	
	
	
	void Start () {
		//GameObject obj = (GameObject) Instantiate(shoot_effect, transform.position  - new Vector3(0,0,5), Quaternion.identity); //Spawn muzzle flash
		
		Destroy(gameObject, 1.5f);
	}
	
	
	
	
	void OnTriggerEnter2D(Collider2D col) {

		//Don't want to collide with the ship that's shooting this thing, nor another projectile.
		if (col.gameObject != firing_ship && col.gameObject.tag != "Projectile" && col.gameObject.tag != "Boundary" && col.gameObject.tag !="Boss"/* && */) {
			//Instantiate(hit_effect, transform.position, Quaternion.identity);
			if(col.gameObject.tag != "Player")
			{
                Destroy(col.gameObject);
			}
			
            
            Destroy(gameObject);
			
		}

        if (col.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
		if(col.gameObject.tag == "Boss")
		{
			col.gameObject.GetComponent<BossKoBoss>().GetHit(damage);
			Destroy(gameObject);
			Debug.Log("Hit");
		}

    }
   



}
