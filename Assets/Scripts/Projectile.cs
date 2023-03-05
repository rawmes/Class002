using UnityEngine;


public class Projectile : MonoBehaviour {

	public float damage = 1f;
	[SerializeField]public bool pooled;
	[SerializeField] public GameObject firing_ship;

	
	
	
	void OnEnable () 
	{
		Invoke("KillMe", 1.5f);
	}
	
	
	
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject != firing_ship && col.gameObject.tag != "Projectile" && col.gameObject.tag != "Boundary" && col.gameObject.tag !="Boss"/* && */) {
			
			if(col.gameObject.tag != "Player")
			{
                Destroy(col.gameObject);
			}
			
            
            KillMe();
			
		}

        if (col.gameObject.tag == "Boundary")
        {
            KillMe();
        }
		if(col.gameObject.tag == "Boss")
		{
			col.gameObject.GetComponent<BossKoBoss>().GetHit(damage);
			KillMe();
			Debug.Log("Hit");
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
