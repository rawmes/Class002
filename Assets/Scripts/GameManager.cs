
using TMPro;

using UnityEngine;

using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [SerializeField] TextMeshProUGUI texter;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField] SceneManagementSystem sceneManager;
    [SerializeField] GameObject player;
    [SerializeField] GameObject bg;
    [SerializeField] GameObject fog;
    [SerializeField] public float playerMaxHealth;
    [SerializeField]public float  playerHealth;
    PlayerControls playerScript;
    BackgroundMove bgScript;
    BackgroundMove fgScript;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] GameObject buttonPrefab;

    BossKoBoss currentBoss;
    

    public bool bossMood=false;

    bool paused = false;

    

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        

        playerScript = player.GetComponent<PlayerControls>();
        bgScript= bg.GetComponent<BackgroundMove>();    
        fgScript = fog.GetComponent<BackgroundMove>();

        playerScript.paused= false;
        bgScript.scroll = true;
        fgScript.scroll = true;
        

    }

    private void OnEnable()
    {
        PlayerControls.playerDies += PlayerDead;
    }

    private void OnDisable()
    {
        PlayerControls.playerDies -= PlayerDead;    
    }
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(_instance);
    }

    private void Update()
    {
        if (dialogueManager.isWriting)
        {
            dialogueManager.MakeButtonsInactive(dialogueManager.choices);
        }
        else
        {
            dialogueManager.MakeButtonsActive(dialogueManager.choices); 
        }
        
    }
    void PlayerDead()
    {
        Debug.Log("GameOVER");
        LoseGame();

    }

    public bool bossStatus()
    {
        return bossMood;
    }

    public void StartDialogue()
    {
        dialogueManager.Initialize();
        
    }

    public void ChangePlayerHealth(float health)
    {
        playerHealth = health;
    }

    public void WinGame()
    {
        Destroy(currentBoss);
        //Time.timeScale = 0f;
        texter.gameObject.SetActive(true);
        texter.text = "Winner";
        
        Invoke("LoadMainMenu", 2f);

        //next scene ra main menu yeta
    }

    public void LoseGame()
    {
        //Time.timeScale = 0f;
        texter.gameObject.SetActive(true);
        texter.text = "Loser";
        Invoke("LoadMainMenu", 2f);

        //restart ra main menu yeta or something

    }
    
    public void SetCurrentBoss(BossKoBoss boss)
    {
        currentBoss = boss;
    }

    void ReloadScene()
    {
        //reload scene
    }

    void LoadMainMenu()
    {
        sceneManager.LoadMainMenu();
    }

    public void PauseMovements()
    {
        paused = true;
        player.GetComponent<PlayerControls>().paused = true;
        GameObject thisBoss = GameObject.FindGameObjectWithTag("Boss");
        
        
    }
    public void UnPauseMovements()
    {
        paused = false;
        player.GetComponent<PlayerControls>().paused = false;
        
    }

    public bool GetPausedOrNot()
    {
        return paused;
    }
   
    
}
