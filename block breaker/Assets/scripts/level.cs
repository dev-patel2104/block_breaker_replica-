using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class level : MonoBehaviour
{
    [SerializeField] int breakableblock;
     int ballcount;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void countofblock()
    {
        breakableblock++;
    }

    public void blockDestroy()
    {
        breakableblock--;
        if(breakableblock <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
    
    
}
