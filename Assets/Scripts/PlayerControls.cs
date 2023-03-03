
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public static event UnityAction playerHit;

    [SerializeField] private float inputX;
    [SerializeField] private float inputY;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    
    private Vector3 reference = Vector3.zero;
    [SerializeField] private float smoothValue;
    public bool paused;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
        inputY= context.ReadValue<Vector2>().y;
        

       
    }
    private void FixedUpdate()
    {
        if (!paused)
        {
            Vector3 targetVel = new Vector3(inputX * moveSpeed * Time.fixedDeltaTime, inputY * moveSpeed * Time.fixedDeltaTime, gameObject.transform.position.z);

            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVel, ref reference, smoothValue);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }



    private void Update()
    {
        //sir said this bad place

    }

    public void Ouchie()
    {
        playerHit?.Invoke();
    }
}
