
using UnityEngine;


public class BossKoBoss : MonoBehaviour
{
    public int stateIndex;
    public float Health=100f;
    public bool activated = false;

    public WeaponSystem[] WeaponSystems;

    [SerializeField] public float[] checkpoints;

    public UnitStateMachine disabledState = new BossDisabledState();
    public UnitStateMachine chillState = new BossPlayState();
    public UnitStateMachine annoyedState = new BossAnnoyedState();
    public UnitStateMachine angryState = new BossAngryState();

    UnitStateMachine oldState;
    UnitStateMachine currentState;

    public int iterator;

    private void Start()
    {
        SwitchState(disabledState);
    }

    private void Update()
    {
        if(currentState != null)
        {
            currentState.UpdateState(this);
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
}
