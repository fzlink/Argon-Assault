using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    private int score;
    private Text scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = GetComponent<Text>();
        scoreBoard.text = score.ToString();
    }
    
    public void ScoreHit(int scorePerHit)
    {
        score += scorePerHit;
        scoreBoard.text = score.ToString();
    }
}
