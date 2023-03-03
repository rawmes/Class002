
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    bool ossilator = true;
    public static event Action<Story> OnCreateStory;

    [SerializeField] private Canvas dialogueCanvas;

    [SerializeField] TextMeshProUGUI npcTalkSpace;
    [SerializeField] TextMeshProUGUI playerTalkSpace;

    [SerializeField] Button[] choices;
    int choiceIndex = 0;

    [SerializeField] TextAsset inkJSONAsset = null;

    public Story story;

    private void Awake()
    {
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

            WriteToScreen(text);
        }

        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {
            choiceIndex = 0;
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Debug.Log(story.currentChoices.Count);
                Choice choice = story.currentChoices[i];
                WriteToButtons(choice.text.Trim());
                
            }
           
        }
        // If we've read all the content and there's no choices, the story is finished!
        
    }

    void CreateContentView(string text)
    {
        TextMeshProUGUI storyText;
        if (ossilator)
        {
            storyText = npcTalkSpace;
            ossilator= false;

        }
        else
        {
            storyText = playerTalkSpace;
            ossilator = true;
        }
        storyText.text = text;
        //storyText.transform.SetParent(dialogueCanvas.transform, false);
    }

    void CreateChoiceView(string text)
    {
        // Gets the text from the button prefab
        TextMeshProUGUI choiceText = choices[choiceIndex].GetComponentInChildren<TextMeshProUGUI>();
        choiceText.text = text;
        choiceIndex++;

    }

    void OnClickChoiceButton()
    {
        
        RefreshView();
    }

    void WriteToScreen(string text)
    {
        TextMeshProUGUI currentText = (ossilator) ? npcTalkSpace: playerTalkSpace;

        currentText.text = text;
    }

    void WriteToButtons(string text)
    {
        TextMeshProUGUI currentChoice = choices[choiceIndex].GetComponentInChildren<TextMeshProUGUI>();
        currentChoice.text = text;
        choiceIndex++;
    }

}
