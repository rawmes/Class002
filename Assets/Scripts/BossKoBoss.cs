
using UnityEngine;
using UnityEngine.UI;

public class BossKoBoss : MonoBehaviour
{
    public int stateIndex;
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentHealth;
    public bool activated = false;
    public bool friendlyStatus;

    

    public WeaponSystem[] WeaponSystems;

    [SerializeField] public float[] checkpoints;
    
    

    public UnitStateMachine disabledState = new BossDisabledState();
    public UnitStateMachine chillState = new BossPlayState();
    public UnitStateMachine annoyedState = new BossAnnoyedState();
    public UnitStateMachine angryState = new BossAngryState();


    public HealthScript healthScript = new HealthScript();

    UnitStateMachine oldState;
    UnitStateMachine currentState;
    [SerializeField] public Image healthBar;

    public int iterator;

    private void Start()
    {
        healthScript.Initialize(maxHealth, healthBar);
        currentHealth = healthScript.GetCurrentHealth();
        SwitchState(disabledState);
        GameManager.Instance.SetCurrentBoss(this);

        
    }

    private void Update()
    {
        if(currentState != null)
        {
            currentState.UpdateState(this);
        }
        if (GameManager.Instance.bossMood)
        {
            activated = false;
            //put death animation here maybe.. or not whatever
            Invoke("WinGame", 1f);
        }
        
        
    }

    public void SwitchState(UnitStateMachine state)
    {

        if (currentState != null)
        {
            oldState = currentState;
            currentState.ExitState(this);
        }
        currentState= state;
        currentState.EnterState(this);

       
    }

    public void GetHit(float damage)
    {
        healthScript.Spanked(damage);
        currentHealth = healthScript.GetCurrentHealth();
        if(currentHealth <=0 )
        {
            Invoke("WinGame", 1f);
            
            
            
        }
    }
    void WinGame()
    {
        GameManager.Instance.WinGame();
    }
    private void OnDisable()
    {
        
       
    }
}
