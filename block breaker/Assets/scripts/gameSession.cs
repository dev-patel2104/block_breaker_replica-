using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameSession : MonoBehaviour
{ 
    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 20;
    [SerializeField] int CurrentScore = 0;
    [SerializeField] TextMeshProUGUI ScoreText;
    // Start is called before the first frame update

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<gameSession>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        ScoreText.text = CurrentScore.ToString();
    }
  
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    
    public void AddToScore()
    {
        CurrentScore = CurrentScore + pointsPerBlockDestroyed;
        ScoreText.text = CurrentScore.ToString();
    }
    public void resetScore()
    {
        Destroy(gameObject);
    }

}
