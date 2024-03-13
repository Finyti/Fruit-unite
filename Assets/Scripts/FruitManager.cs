using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{

    public List<FruitConnection> fruitConnections = new List<FruitConnection>();
    public List<GameObject> allFruits = new List<GameObject>();

    public GameManager gameManager;
    public class FruitConnection
    {
        public GameObject firstFruit = null;
        public GameObject secondFruit = null;
    }

    void Update()
    {
        if (fruitConnections.Count >= 1)
        {
            MergeFruits();
        } 
    }

    public void AddConnection(GameObject newFruit)
    {
        if (allFruits.Contains(newFruit)) return;
        if (fruitConnections.Count == 0)
        {
            CreateConnection(newFruit);
            return;
        }
        bool added = false;
        foreach (var connection in fruitConnections)
        {
            if(connection.secondFruit == null)
            {
                if(connection.firstFruit.GetComponent<FruitLogic>().mergePoints == newFruit.GetComponent<FruitLogic>().mergePoints)
                {
                    connection.secondFruit = newFruit;
                    added = true;
                    allFruits.Add(newFruit);
                }
            }
        }
        if(!added)
        {
            CreateConnection(newFruit);
        }
    }

    public void CreateConnection(GameObject newFruit)
    {
        allFruits.Add(newFruit);
        fruitConnections.Add(new FruitConnection());
        fruitConnections[fruitConnections.Count - 1].firstFruit = newFruit;
    }
    public void MergeFruits()
    {
        foreach (var conection in fruitConnections)
        {
            if (conection.secondFruit == null) continue;
            var newFruit = Instantiate(conection.firstFruit.GetComponent<FruitLogic>().mergePrefab, conection.firstFruit.transform.position, conection.firstFruit.transform.rotation);
            newFruit.GetComponent<FruitLogic>().fruitManager = gameObject.GetComponent<FruitManager>();

            Destroy(conection.firstFruit);
            Destroy(conection.secondFruit);
        }
        for (int i = fruitConnections.Count-1; i >= 0; i--)
        {
            if (fruitConnections[i].secondFruit == null) continue;
            fruitConnections.RemoveAt(i);
        }

    }
}
