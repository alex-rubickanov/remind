using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    float timer = 3;

    [SerializeField] private GameObject[] jumpscare;

    [SerializeField] GameObject currentObject;


    void Start()
    {
        
        InstantiateNewObject();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SceneManager.LoadScene(7);
        }
    }
    void InstantiateNewObject()
    {
        Instantiate(jumpscare[Random.Range(0, 7)]);

    }
}
