using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;

    public Text livesText;
    public Text scoreText;
    
    public Text highScoreText;

    public int highScore {get; private set;}
    public int ghostMultiplier {get; private set; } = 1;
    public int score {get; private set;}
    public int lives {get; private set;}


    // Start is called before the first frame update
    private void Start()
    {
        // Switch to 640 x 480 full-screen
        Screen.SetResolution(640, 480, true);
        NewGame();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
       
    }

    // Update is called once per frame
    private void Update()
    {
        if(this.lives <=0 && Input.anyKeyDown){
            NewGame();
        }
    }
    private void NewGame()
    {   if (score > PlayerPrefs.GetInt("HighScore",0)){
        SetHighScore(score);
        }
        
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound(){
        foreach (Transform pellet in this.pellets){
            pellet.gameObject.SetActive(true);
        }
        ResetState();
    }

    private void ResetState()
    {
        ResetGhostMultiplier();

        for (int i=0; i<this.ghosts.Length; i++){
            this.ghosts[i].ResetState();
        }
        this.pacman.ResetState();
    }

    private void GameOver(){
        for (int i=0; i<this.ghosts.Length; i++){
            this.ghosts[i].gameObject.SetActive(false);
        }
        this.pacman.gameObject.SetActive(false);
    }


    private void SetScore(int score){
        this.score = score;
        scoreText.text = score.ToString().PadLeft(2, '0');

        
    }

    private void SetHighScore(int highScore){
        this.highScore = highScore;
        highScoreText.text = highScore.ToString().PadLeft(2, '0');
        
        if (score > PlayerPrefs.GetInt("HighScore",0)){
        PlayerPrefs.SetInt("HighScore", highScore);
        }
        
    }

    private void SetLives(int lives){
        this.lives=lives;
        livesText.text = "x" + lives.ToString();
    }

    public void GhostEaten(Ghost ghost){
        SetScore(this.score + (ghost.points *this.ghostMultiplier));
        this.ghostMultiplier++;
    }

    public void PacmanEaten(){

        this.pacman.gameObject.SetActive(false);

        SetLives(this.lives -1);

        if(this.lives > 0){
            Invoke(nameof(ResetState), 3.0f);
        } else {
            GameOver();
        }
    }
    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);

        SetScore(this.score + pellet.points);

        if (!HasRemainingPellets())
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }

    public void PowerPelletEaten(PowerPellet pellet)
    {
        for(int i = 0; i<this.ghosts.Length; i++){
            this.ghosts[i].frightened.Enable(pellet.duration);
        }

        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
        CancelInvoke();
        PelletEaten(pellet);
    }

   private bool HasRemainingPellets()
    {
        foreach (Transform pellet in this.pellets)
        {
            if (pellet.gameObject.activeSelf) {
                return true;
            }
        }
        return false;
    }
    private void ResetGhostMultiplier()
    {
        this.ghostMultiplier = 1;
    }

}

