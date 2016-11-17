using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int _livesValue;
    private int _scoreValue;
    public GameObject laser01;

    [Header("UI Objects")]
    public Text LivesLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text FinalScoreLabel;
    public Button RestartButton;

    [Header("Game Objects")]
    public GameObject player;
    public GameObject enemy;

    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                this._endGame();
            }
            else
            {
                this.LivesLabel.text = "Lives: " + this._livesValue;
            }
        }
    }

    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }



    void Start()
    {
        this.LivesValue = 5;
        this.ScoreValue = 0;

        this.GameOverLabel.gameObject.SetActive(false);
        this.FinalScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);

        

    }

    void Update()
    {
    }

    private void _endGame()
    {
        this.GameOverLabel.gameObject.SetActive(true);
        this.FinalScoreLabel.text = "Final Score: " + this.ScoreValue;
        this.FinalScoreLabel.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.ScoreLabel.gameObject.SetActive(false);
        this.LivesLabel.gameObject.SetActive(false);
        this.player.SetActive(false);
        this.enemy.SetActive(false);
    }

    public void RestartButton_Click()
    {
        SceneManager.LoadScene("Main");
    }
}
