using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int newScoreValue) 
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore() 
    {
        scoreText.text = "Score: " + score;
    }

}
