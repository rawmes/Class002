
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] AudioClip typingSound;
    AudioSource audioPlayer;
    string[] currentChoices = new string[4];
    bool ossilator = true;
    [SerializeField] public bool isWriting=false;
    public static event Action<Story> OnCreateStory;
    [SerializeField] EnemySpawner spawnManager;
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] TextMeshProUGUI npcTalkSpace;
    [SerializeField] TextMeshProUGUI playerTalkSpace;

    [SerializeField]public Button[] choices;
    int choiceIndex = 0;
    [SerializeField] TextAsset inkJSONAsset = null;
    public Story story;
    public void Initialize()
    {
        audioPlayer = GetComponent<AudioSource>();
        dialogueCanvas.gameObject.SetActive(true);
        StartStory();
        Time.timeScale = 0f;
    }
    void StartStory()
    {
        story = new Story(inkJSONAsset.text);
        if (OnCreateStory != null) OnCreateStory(story);
        RefreshView();
    }
    void RefreshView()
    {
       
        while (story.canContinue)
        {
            string text = story.Continue();
            
            text = text.Trim();
            if (ossilator && text[0] != '<')
            {
                WriteToScreen(text);
            }
           
        }

        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {
            choiceIndex = 0;
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Debug.Log(story.currentChoices.Count);
                Choice choice = story.currentChoices[i];
                currentChoices[i] = ChoiceParser(0, choice.text);
                WriteToButtons(ChoiceParser(1,choice.text));
                
            }
            MakeButtonsInactive(choices);
            
        }
        else
        {
            
            StartCoroutine(EndDialogue(3));
        }
    }
    void CreateChoiceView(string text)
    {
        // Gets the text from the button prefab
        TextMeshProUGUI choiceText = choices[choiceIndex].GetComponentInChildren<TextMeshProUGUI>();
        choiceText.text = text;
        choiceIndex++;

    }
    void OnClickChoiceButton(int index)
    {
        try
        {
            story.ChooseChoiceIndex(index);
            playerTalkSpace.text = currentChoices[index];
        }
        catch
        {
            Debug.Log("i fix bug by try /catch .. what about you?");
        }
        
        
        StartCoroutine(Delayer(1f));
    }
    IEnumerator Delayer(float time)
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(time);
        yield return wait;
        RefreshView();
    }
    
    public void Choice001()
    {
        OnClickChoiceButton(0);
    }

    public void Choice002()
    {
        ossilator = false;
        OnClickChoiceButton(1);
    }

    void WriteToScreen(string text)
    {
        TextMeshProUGUI currentText = npcTalkSpace;

        StartCoroutine(Type(currentText , text ));
        
    }

    IEnumerator Type(TextMeshProUGUI box, string text)
    {
        string old="";
        isWriting = true;
       
        float tiem = 0.02f;
        float anotherTiem = 0.06f;
        float waiter = tiem;
        string holder = text;
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(waiter);
        foreach(char a in holder)
        {
            
            yield return wait;
            waiter = (a == ' ') ? anotherTiem : tiem;
            audioPlayer.clip = typingSound;
            audioPlayer.Play();

            isWriting = true;

            old += a;
            box.text = old;
           
        }

        
        
        isWriting = false;
        

    }
    void WriteToButtons(string tt)
    {
        
        TextMeshProUGUI currentChoice = choices[choiceIndex].GetComponentInChildren<TextMeshProUGUI>();
        currentChoice.text = tt;
        choiceIndex++;
    }

    public void MakeButtonsInactive(Button[] objs)
    {
        foreach(Button obj in objs)
        {
            obj.gameObject.SetActive(false);
        }
    }
    public void MakeButtonsActive(Button[] objs)
    {
        foreach(Button obj in objs)
        {
            obj.gameObject.SetActive(true);
        }
    }

    string ChoiceParser(int state,string text)
    {
        string a ="", b="";
        bool switcher = false;
        foreach(char x in text)
        {
            if(x !=  '<' && x!='>') 
            {
                if (switcher)
                {
                    a = a + x;
                }
                else
                {
                    b=b + x;
                }
            }
            if(x == '>')
            {
                switcher = true;
            }
        }

        switch (state)
        {
            case 0:
                return a;
                
            case 1:
                return b;
            
            
        }

        Debug.Log("Check Dialogue manager script for this error.");
        return "only 2 halves for now;";

    }
    IEnumerator EndDialogue(float time)
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(time);
        yield return wait;
        dialogueCanvas.enabled = false;

        GameManager.Instance.bossMood = ossilator;
        ossilator = true;
        
        Time.timeScale = 1f;
    }
}
