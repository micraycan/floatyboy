using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float currentScore;
    public float spawnSpeed;
    public float speed;
    public Text scoreText;
    public Text highScoreText;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score: " + currentScore;
        highScoreText.text = "highest: " + PlayerPrefs.GetFloat("highScore");

        float acceleration = 1 / 10000f;
        speed += acceleration;

        spawnSpeed -= acceleration;

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ScorePoint()
    {
        currentScore++;
        PlayerPrefs.SetFloat("currentScore", currentScore);
        SetHighScore();
    }

    public void ResetScore()
    {
        currentScore = 0f;
    }

    public void SetHighScore()
    {
        if (currentScore > PlayerPrefs.GetFloat("highScore"))
        {
            PlayerPrefs.SetFloat("highScore", currentScore);
        }
    }

    public float IncreaseSpeed()
    {
        return Time.timeSinceLevelLoad / 1f;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
