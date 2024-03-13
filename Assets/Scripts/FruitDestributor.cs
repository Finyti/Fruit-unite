using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class FruitDestributor : MonoBehaviour
{
    public List<GameObject> fruitPrefab = new List<GameObject>();
    public FruitManager fruitManager;
    public GameManager gameManager;
    public float spawnCooldown;

    public bool canSpawn = true;
    public bool canDrop = false;

    public float destributorRange;

    GameObject holdingFruit = null;

    public AudioClip fallSound;


    void Update()
    {
        if (!gameManager.gameGoing) return;
        Vector3 mouseToWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mousePositionX = mouseToWorldPosition.x;

        if (mousePositionX < destributorRange + 1 && -destributorRange < mousePositionX)
        {

            transform.position = new Vector2 (mousePositionX, transform.position.y);
        }



        if (holdingFruit == null && canSpawn)
        {
            FruitSpawn();
        }
        if (Input.GetMouseButtonDown(0) && holdingFruit != null && canDrop)
        {
            FruitDrop();
        }
    }

    public async void FruitSpawn()
    {
        int randomFruitIndex = Random.Range(0, fruitPrefab.Count);

        //yield return new WaitForSeconds(spawnCooldown);

        holdingFruit = Instantiate(fruitPrefab[randomFruitIndex], transform.position, transform.rotation);
        holdingFruit.transform.eulerAngles += new Vector3(0, 0, 45);

        holdingFruit.GetComponent<Rigidbody2D>().gravityScale = 0;
        holdingFruit.transform.parent = transform;
        holdingFruit.transform.position -= new Vector3(0.5f, 0.3f, 0);
        holdingFruit.GetComponent<FruitLogic>().fruitManager = fruitManager;

        await new WaitForSeconds(0.3f);

        canDrop = true;
        canSpawn = false;
    }

    public async void FruitDrop()
    {
        canDrop = false;

        holdingFruit.GetComponent<Rigidbody2D>().gravityScale = 1;
        holdingFruit.transform.parent = null;
        holdingFruit.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        holdingFruit.transform.position += new Vector3(Random.Range(-0.05f, 0.05f), 0, 0);

        AudioManager.Play(fallSound, 3f);
        await new WaitForSeconds(0.3f);
        if(holdingFruit != null)
        {
            holdingFruit.GetComponent<FruitLogic>().inGame = true;
        }
        await new WaitForSeconds(spawnCooldown);
        holdingFruit = null;

        canSpawn = true;
    }




}
