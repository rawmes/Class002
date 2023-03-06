using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    float frame;
    float timer;
    TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = "Fps:??";
    }
    void Update()
    {
        if(timer <= 1f)
        {
            timer += Time.deltaTime;
            frame++;

        }
        else
        {
            string text = "Fps: "+frame.ToString();
            textMeshPro.text = text;
            frame = 0;
            timer = 0f;

        }
        
    }
}
