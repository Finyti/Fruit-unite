using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitLogic : MonoBehaviour
{
    public int mergePoints = 0;
    public bool destroyOnMerge = false;
    public GameObject mergePrefab;
    public FruitManager fruitManager;

    public bool inGame = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObjectFL = collision.gameObject.GetComponent<FruitLogic>();
        if (collisionObjectFL != null)
        {
            if(collisionObjectFL.mergePoints == mergePoints)
            {
                fruitManager.AddConnection(gameObject);
            }
        }
    }
}

