
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public static event UnityAction playerDies;

    AudioSource playerAudioSource;
    [SerializeField] AudioClip fireBulletSound;

    [SerializeField] private float inputX;
    [SerializeField] private float inputY;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    
    private Vector3 reference = Vector3.zero;
    [SerializeField] private float smoothValue;
    public bool paused;

    [SerializeField] WeaponSystem weaponSystem;

    float maxHealth, currentHealth;
    [SerializeField] Image healthBar;

    public HealthScript healthScript = new HealthScript();

    private void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        maxHealth = GameManager.Instance.playerMaxHealth;
        healthScript.Initialize(maxHealth, healthBar);
        weaponSystem.MakeBullet();

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

            rb.velocity = targetVel; 
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started && Time.timeScale != 0)            
        {
            weaponSystem.FirePool();
            playerAudioSource.clip = fireBulletSound;
            playerAudioSource.Play(); 
        }
        
    }



    private void Update()
    {
        //sir said this bad place

    }

    public void Ouchie(float damage)
    {
        healthScript.Spanked(damage);
        currentHealth = healthScript.GetCurrentHealth();
        GameManager.Instance.ChangePlayerHealth(currentHealth);
        if(healthScript.GetCurrentHealth() <= 0f)
        {
            playerDies?.Invoke();
        }
    }
}
