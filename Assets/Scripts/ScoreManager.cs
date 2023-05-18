using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + score.ToString(); 
    }

    public void AddCoin(int _score){
        score += _score;
        scoreText.text = "Score : " + score.ToString(); 
    }
}
