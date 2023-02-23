using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMove : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    [SerializeField] Vector2 offset;
   [SerializeField] Material spriteMaterial;
    private void Awake()
    {
        spriteMaterial=GetComponent<SpriteRenderer>().material;
    }

    public void Update()
    {
        offset = moveSpeed*Time.deltaTime;
        spriteMaterial.mainTextureOffset+= offset;
    }
}
