using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitDestributor : MonoBehaviour
{
    public List<GameObject> fruitPrefab = new List<GameObject>();
    public FruitManager fruitManager;
    public float spawnCooldown;
    public float dropCooldown;

    public float destributorRange;

    GameObject holdingFruit = null;
    void Start()
    {
        
    }


    void Update()
    {

        Vector3 mouseToWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mousePositionX = mouseToWorldPosition.x;

        if (mousePositionX < destributorRange + 1 && -destributorRange < mousePositionX)
        {

            transform.position = new Vector2 (mousePositionX, transform.position.y);
        }



        if (holdingFruit == null)
        {
            spawnCooldown -= Time.deltaTime;
            if (spawnCooldown <= 0)
            {
                FruitSpawn();
            }
            
        }
        dropCooldown -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && dropCooldown <= 0 && holdingFruit != null)
        {
            FruitDrop();
        }
    }

    public void FruitSpawn()
    {
        int randomFruitIndex = Random.Range(0, fruitPrefab.Count);

        //yield return new WaitForSeconds(spawnCooldown);

        holdingFruit = Instantiate(fruitPrefab[randomFruitIndex], transform.position, transform.rotation);
        holdingFruit.transform.eulerAngles += new Vector3(0, 0, 45);

        holdingFruit.GetComponent<Rigidbody2D>().gravityScale = 0;
        holdingFruit.transform.parent = transform;
        holdingFruit.transform.position -= new Vector3(0.5f, 0.3f, 0);
        holdingFruit.GetComponent<FruitLogic>().fruitManager = fruitManager;
        spawnCooldown = 1;
    }

    public void FruitDrop()
    {
        holdingFruit.GetComponent<Rigidbody2D>().gravityScale = 1;
        holdingFruit.transform.parent = null;
        holdingFruit.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        holdingFruit.transform.position += new Vector3(Random.Range(-0.05f, 0.05f), 0, 0);

        dropCooldown = 1;
        holdingFruit = null;
    }


}
