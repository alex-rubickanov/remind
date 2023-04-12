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

    GameObject fridgeNotes;

    bool houseSceneOnce = false;
    bool parentsSceneOnce = false;

    public bool isDishwashingCompleted = false;
    public bool isCabinetMinigameCompleted = false;
    public bool isTableMinigameCompleted = false;
    

    [SerializeField] GameObject dishwashingCompleted;
    [SerializeField] GameObject cabinetCompleted;

    [SerializeField] public PreviousScene index;


    public bool isParentsRoomExitTrigger = false;
    public bool isChildrenRoomExitTrigger = false;
    


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
        pauseMenu = Instantiate(pauseMenu);
        
        pauseMenu.SetActive(false);
        pastPos.initialValue = new Vector3(-3.7f, -1.1f, 0f);
        
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
            isTableMinigameCompleted = false;
            isCabinetMinigameCompleted = false;
            isDishwashingCompleted = false;
            houseSceneOnce = false;
            isGameOnPause = false;
            parentsSceneOnce = false;

            pastPos.initialValue = new Vector3(-3.7f, -1.1f, 0);
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }


        if(!pauseMenu.activeSelf == isGameOnPause) 
        {
            isGameOnPause = pauseMenu.activeSelf;
        }

        if(SceneManager.GetActiveScene().name == "House" && ( isCabinetMinigameCompleted || isDishwashingCompleted || isTableMinigameCompleted))
        {
            GameObject nath = GameObject.Find("Nath");
            Destroy(nath); 
        }

        if(SceneManager.GetActiveScene().name == "House")
        {
            fridgeNotes = GameObject.Find("FridgeNotes");
        }

        if(SceneManager.GetActiveScene().name == "House" && isCabinetMinigameCompleted && isDishwashingCompleted && isTableMinigameCompleted)
        {
            SceneManager.LoadScene(9);
        }



        if (!isGameOnPause || !(Time.timeScale == 0f))
        {
            if (SceneManager.GetActiveScene().name == "ParentsRoom" && Input.GetKeyDown(KeyCode.E) && isParentsRoomExitTrigger)
            {
                SceneManager.LoadScene("House");
                

            }

            if (SceneManager.GetActiveScene().name == "KidsRoom" && Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("House");

            }
            
        }

        if (SceneManager.GetActiveScene().name == "House" && !houseSceneOnce)
        {
            Instantiate(dialogueNathPrefab);
            houseSceneOnce = true;
        }

        if (SceneManager.GetActiveScene().name == "ParentsRoom" && !parentsSceneOnce)
        {
            Instantiate(bookDialoguePrefab);
            parentsSceneOnce = true;
        }

    }




    //------------------ PAUSE ------------------
    public void Pause()
    {
        if (fridgeNotes == null || !fridgeNotes.activeSelf)
        {
            if (isGameOnPause == false)
            {
                Debug.Log("Pause!");
                Time.timeScale = 0;
                isGameOnPause = true;
                pauseMenu.SetActive(true);
            }
            else if (isGameOnPause == true)
            {
                Debug.Log("Unpause");
                Time.timeScale = 1;
                isGameOnPause = false;
                pauseMenu.SetActive(false);
            }
        }


    }

    public void BackToMainMenuButton()
    {
        
        SceneManager.LoadScene(0);
        
    }


    
}
