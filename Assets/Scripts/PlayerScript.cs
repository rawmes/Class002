using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] Vector2 rawInput;
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 horizontalClamp;
    [SerializeField] Camera Cameracam;
    [SerializeField] Vector2 verticalClamp;
    void Start()
    {
        Cameracam = Camera.main;
        
    }


    public void OnMove(InputValue input)
    {
        rawInput = input.Get<Vector2>();

        rb2D.velocity = rawInput * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
