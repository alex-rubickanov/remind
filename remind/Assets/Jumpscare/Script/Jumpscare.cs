using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    float timer = 3;

    [SerializeField] private GameObject[] jumpscare;

    
    [SerializeField] PreviousScene index;


    void Start()
    {
        
        InstantiateNewObject();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SceneManager.LoadScene(index.index);
        }
    }
    void InstantiateNewObject()
    {
        Instantiate(jumpscare[Random.Range(0, 7)]);

    }
}
