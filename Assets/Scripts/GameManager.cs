using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    
    
    [SerializeField] GameObject player;
    [SerializeField] GameObject bg;

    [SerializeField] int playerHealth;
    PlayerControls playerScript;
    backgroundMove bgScript;

    

    private void Start()
    {
        player = GameObject.FindWithTag("Player");


        playerScript = player.GetComponent<PlayerControls>();
        bgScript= bg.GetComponent<backgroundMove>();    

        playerScript.paused= false;
        bgScript.scroll = true;
        

    }

    private void OnEnable()
    {
        PlayerControls.playerHit += PlayerHealth;
    }


    void PlayerHealth()
    {
        playerHealth--;

        if(playerHealth<= 0)
        {
            //Loserrrr
        }

    }


}
