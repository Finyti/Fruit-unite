using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public FruitDestributor fruitDestributor;

    public GameObject biggerFruitPrefabOne;
    public GameObject biggerFruitPrefabTwo;
    void Start()
    {
        
    }

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
}
