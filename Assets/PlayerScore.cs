using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text scoreText;
    public int score;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore()
    {
        score += 100;
        scoreText.text = "Score: " + score.ToString();
    }

    public void DecreaseScore()
    {
        score -= 100;
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
