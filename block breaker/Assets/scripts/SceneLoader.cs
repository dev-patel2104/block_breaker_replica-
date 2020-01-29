using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadNextScene()
    {
        
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene + 1);
    }
    public void LoadStartScene()
    {
       
        SceneManager.LoadScene(0);
       FindObjectOfType<gameSession>().resetScore();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
