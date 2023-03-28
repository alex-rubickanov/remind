using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    bool isGameOnPause = false;
    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject playerPrefab;
    

    [SerializeField] VectorValue pastPos;
    [SerializeField] Player player;

    [SerializeField] GameObject bookDialoguePrefab;
    [SerializeField] GameObject dialogueNathPrefab;

    [SerializeField] Canvas fridgeNotes;

    bool houseSceneOnce = true;

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
        //DontDestroyOnLoad(pauseMenu);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }


        

        



        if (!isGameOnPause)
        {
            if (SceneManager.GetActiveScene().name == "ParentsRoom" && Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("House");
                if (SceneManager.GetActiveScene().name == "House" && houseSceneOnce)
                {
                    Instantiate(dialogueNathPrefab);
                }

            }

            if (SceneManager.GetActiveScene().name == "KidsRoom" && Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("House");

            }
            
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
            player.isAbleToInput = false;
        } else if (isGameOnPause == true) 
        {   
            Debug.Log("Unpause");
            Time.timeScale = 1;
            isGameOnPause = false;
            pauseMenu.SetActive(false);
            player.isAbleToInput = true;
        }
    }

    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }


    
}
