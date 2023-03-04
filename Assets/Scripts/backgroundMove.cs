using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    [SerializeField] Vector2 offset;
    [SerializeField] Material spriteMaterial;
    [SerializeField] Material fogMat;
    public bool scroll;
    private void Start()
    {
       
    }
    private void Awake()
    {
        spriteMaterial=GetComponent<SpriteRenderer>().material;
    }

    public void Update()
    {
        if (scroll)
        {
            offset = moveSpeed * Time.deltaTime;
            spriteMaterial.mainTextureOffset += offset;

        }
        
    }
}
