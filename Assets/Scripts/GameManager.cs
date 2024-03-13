using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public GameObject GameOverPanel;
    public TextMeshProUGUI gameEndScoreText;


    public FruitDestributor fruitDestributor;

    public GameObject biggerFruitPrefabOne;
    public GameObject biggerFruitPrefabTwo;

    public AudioClip loseSound;

    public bool gameGoing = true;

    
    void Update()
    {
        if(Int32.Parse(scoreText.text) >= 300 && biggerFruitPrefabOne != null)
        {
            fruitDestributor.fruitPrefab.Add(biggerFruitPrefabOne);
            biggerFruitPrefabOne = null;
        }
        if (Int32.Parse(scoreText.text) >= 900 && biggerFruitPrefabTwo != null)
        {
            fruitDestributor.fruitPrefab.Add(biggerFruitPrefabTwo);
            biggerFruitPrefabTwo = null;
        }
    }

    public void AddScore(int points)
    {
        scoreText.text = (Int32.Parse(scoreText.text) + points).ToString();
    }

    public async void GameOver()
    {
        AudioManager.Play(loseSound, 1f);
        await new WaitForSeconds(1);
        GameOverPanel.active = true;
        gameEndScoreText.text = "Score: " + scoreText.text;
        gameGoing = false;
    }

    public async void NewGame()
    {
        await new WaitForSeconds(1);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
