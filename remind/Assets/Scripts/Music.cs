using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    static Music instance;

    private void Awake() //singleton
    {
        if (instance == null && instance != this)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
            
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            gameObject.GetComponent<AudioSource>().volume = 0;
        } else
        {
            gameObject.GetComponent<AudioSource>().volume = 0.146f;
        }

        
        if(SceneManager.GetActiveScene().name == "EndCutscene")
        {
            Destroy(gameObject);
        }
    }

}
