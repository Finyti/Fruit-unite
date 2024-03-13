using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverflowLogic : MonoBehaviour
{
    public GameManager manager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {

            FruitLogic fl = collision.gameObject.GetComponent<FruitLogic>();
            if (fl.inGame)
            {

                manager.GameOver();
            }
        }
    }
}
