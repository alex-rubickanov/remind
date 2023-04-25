using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    [Header("PAUSE MENU")]
    [SerializeField] bool isGameOnPause = false;
    [SerializeField] GameObject pauseMenu;

    [Header("PLAYER")]
    [SerializeField] GameObject playerPrefab;
    [SerializeField] VectorValue pastPos;
    [SerializeField] Player player;

    [Header("DIALOGUES")]
    [SerializeField] GameObject bookDialoguePrefab;
    [SerializeField] GameObject dialogueNathPrefab;

    [Header("CUTSCENES")]
    public bool isFirstCutsceneEnd = false;
    public bool isSecondCutsceneEnd = false;
    GameObject darkEffect;

    GameObject fridgeNotes;

    bool houseSceneOnce = false;
    bool parentsSceneOnce = false;

    [Header("MINIGAMES")]
    public bool isDishwashingCompleted = false;
    public bool isCabinetMinigameCompleted = false;
    public bool isTableMinigameCompleted = false;
    //[SerializeField] GameObject dishwashingCompleted;
    //[SerializeField] GameObject cabinetCompleted;


    [Header("SCENE MANAGER")]
    [SerializeField] public PreviousScene index;

    [Header("ROOMS TRIGGERS")]
    public bool isParentsRoomExitTrigger = false;
    public bool isChildrenRoomExitTrigger = false;

    [Header("SCREEN INFO")]
    public float height;
    public float width;
    public bool isAnnaAspect = false; 

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
        
        darkEffect = GameObject.Find("DarkEffect");
        
        
        pauseMenu.SetActive(false);
        pastPos.initialValue = new Vector3(-3.7f, -1.1f, 0f);
        
        height = Screen.height;
        width = Screen.width;

        if(width / height >= 1.6 && width / height <= 1.7)
        {
            isAnnaAspect = true;
        }

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(pauseMenu);
        DontDestroyOnLoad(darkEffect);
    }

    private void Update()
    {
        
        Debug.Log(Screen.safeArea);

        if (SceneManager.GetActiveScene().name != "EndCutscene1" || SceneManager.GetActiveScene().name != "EndCutscene2")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
        

        if(isCabinetMinigameCompleted == true)
        {
            Debug.Log("Completed");
            
        }

        if (isDishwashingCompleted == true)
        {
            Debug.Log("Completed");
            
        }

        if(isFirstCutsceneEnd == true) 
        {
            darkEffect.GetComponent<Canvas>().enabled = true;
        } else if(isFirstCutsceneEnd == false) {
            darkEffect.GetComponent<Canvas>().enabled = false;
        }

        if(!isSecondCutsceneEnd && isFirstCutsceneEnd && isCabinetMinigameCompleted && isTableMinigameCompleted && isDishwashingCompleted && SceneManager.GetActiveScene().name != "EndCutscene2")
        {
            SceneManager.LoadScene("EndCutscene2");
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

        if(SceneManager.GetActiveScene().name == "KidsRoom" && isCabinetMinigameCompleted && isDishwashingCompleted && isTableMinigameCompleted && !isFirstCutsceneEnd)
        {
            SceneManager.LoadScene("EndCutscene1");
        }
        

        if (!isGameOnPause || !(Time.timeScale == 0f))
        {
            if (SceneManager.GetActiveScene().name == "ParentsRoom" && Input.GetKeyDown(KeyCode.E) && isParentsRoomExitTrigger)
            {
                isParentsRoomExitTrigger = false;
                SceneManager.LoadScene("House");
                

            }

            if (SceneManager.GetActiveScene().name == "KidsRoom" && Input.GetKeyDown(KeyCode.E) && isChildrenRoomExitTrigger)
            {
                isChildrenRoomExitTrigger = false;
                SceneManager.LoadScene("House");

            }
            
        }

        if(isFirstCutsceneEnd && SceneManager.GetActiveScene().name == "House") 
        {
            GameObject nath = GameObject.Find("Nath");
            if(nath != null) {
                nath.SetActive(false);
            }
            
        }

        if(isFirstCutsceneEnd && SceneManager.GetActiveScene().name == "KidsRoom") 
        {
            GameObject mateo = GameObject.Find("Mateo");
            GameObject maria = GameObject.Find("Maria");
            if(mateo != null && maria != null) {
                maria.SetActive(false);
                mateo.SetActive(false);
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

        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Cutscene")
        {
            Time.timeScale = 1f;
            isTableMinigameCompleted = false;
            isCabinetMinigameCompleted = false;
            isDishwashingCompleted = false;
            houseSceneOnce = false;
            isGameOnPause = false;
            parentsSceneOnce = false;   
            isFirstCutsceneEnd = false;
            isSecondCutsceneEnd = false;

            pastPos.initialValue = new Vector3(-3.7f, -1.1f, 0);
            pauseMenu.SetActive(false);

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
