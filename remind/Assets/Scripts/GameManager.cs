using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    [SerializeField] bool isGameOnPause = false;
    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject playerPrefab;
    

    [SerializeField] VectorValue pastPos;
    [SerializeField] Player player;

    [SerializeField] GameObject bookDialoguePrefab;
    [SerializeField] GameObject dialogueNathPrefab;

    [SerializeField] Canvas fridgeNotes;

    bool houseSceneOnce = true;

    public bool isDishwashingCompleted = false;
    public bool isCabinetMinigameCompleted = false;
    public bool isTableMinigameCompleted = false;

    [SerializeField] GameObject dishwashingCompleted;
    [SerializeField] GameObject cabinetCompleted;

    [SerializeField] public PreviousScene index;

    private void Awake() //singleton
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    public void Start()
    {
        Instantiate(pauseMenu);
        pauseMenu.SetActive(false);
        pastPos.initialValue = new Vector3(-3.7f, -1.1f, 0f);
        Instantiate(bookDialoguePrefab);
    }

    private void Update()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(pauseMenu);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if(isCabinetMinigameCompleted == true)
        {
            Debug.Log("Completed");
            
        }

        if (isDishwashingCompleted == true)
        {
            Debug.Log("Completed");
            
        }

        if(SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Cutscene")
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }


        if(!pauseMenu.activeSelf == isGameOnPause) 
        {
            isGameOnPause = pauseMenu.activeSelf;
        }





        if (!isGameOnPause || !(Time.timeScale == 0f))
        {
            if (SceneManager.GetActiveScene().name == "ParentsRoom" && Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("House");
                

            }

            if (SceneManager.GetActiveScene().name == "KidsRoom" && Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("House");

            }
            
        }

        if (SceneManager.GetActiveScene().name == "House" && houseSceneOnce)
        {
            Instantiate(dialogueNathPrefab);
            houseSceneOnce = false;
        }

    }




    //------------------ PAUSE ------------------
    public void Pause()
    {
        if (isGameOnPause == false)
        {
            Debug.Log("Pause!");
            Time.timeScale = 0;
            isGameOnPause = true;
            pauseMenu.SetActive(true);
        } else if (isGameOnPause == true) 
        {   
            Debug.Log("Unpause");
            Time.timeScale = 1;
            isGameOnPause = false;
            pauseMenu.SetActive(false);
        }
    }

    public void BackToMainMenuButton()
    {
        isGameOnPause = false;
        SceneManager.LoadScene(0);
        
    }


    
}
