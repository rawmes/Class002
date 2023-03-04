using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryMaintainer : MonoBehaviour
{
    Camera cam;
    float width;
    float height;
    EdgeCollider2D edgeCollider;

    private void Awake()
    {
        cam = Camera.main;
        edgeCollider= GetComponent<EdgeCollider2D>();

    }

    private void Update()
    {
        GetHeightAndWidth();
        MakeBoundary(); 
    }

    void MakeBoundary()
    {
        Vector2 pointa = new Vector2(width / 2, height / 2);
        Vector2 pointb = new Vector2(width / 2, -height / 2);
        Vector2 pointc = new Vector2(-width / 2, -height / 2);
        Vector2 pointd = new Vector2(-width / 2, height / 2);

        Vector2[] temporaryArray = new Vector2[] {pointa, pointb, pointc,pointd, pointa};

        edgeCollider.points = temporaryArray;

    }

    void GetHeightAndWidth()
    {
        width = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f);
        height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - 0.5f);
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
        }
    }
    
    
}
