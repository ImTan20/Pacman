using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour
{
public Text highScoreText;
public int highScore {get; private set;}
private void GetHighScore(int highScore){
        this.highScore = highScore;
        highScoreText.text = highScore.ToString().PadLeft(2, '0');
        
        {
        PlayerPrefs.GetInt("HighScore", highScore);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
