using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    float timer = 3;
    [SerializeField] private GameObject[] jumpscare;
    [SerializeField] private List<GameObject> randomList;

    [SerializeField] int maxRandomArray = 7;

    [SerializeField] GameObject currentObject;


    // Start is called before the first frame update
    void Start()
    {
        randomList = RandomSequence(jumpscare);
        InstantiateNewObject();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SceneManager.LoadScene(7);
        }
    }

    List<GameObject> RandomSequence(GameObject[] gameObjects)
    {
        List<GameObject> randomList = new List<GameObject>();
        for (int i = 0; i < maxRandomArray; i++)
        {
            randomList.Add(gameObjects[Random.Range(0, gameObjects.Length)]);
        }

        return randomList;
    }
    void InstantiateNewObject()
    {
        //currentObject = Instantiate(randomArray[0]);
        if (randomList.Count >= 1)
        {
            currentObject = Instantiate(randomList[0]);
        }

    }
}
