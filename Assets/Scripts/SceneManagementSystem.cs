using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementSystem : MonoBehaviour
{
    public void LoadNextScene ()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex+1);
    }
    public void ExitFunction()
    {
        Application.Quit();
    }
}
