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
    [SerializeField] GameObject[] spawners;

    [SerializeField] VectorValue pastPos;
    


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
        pastPos.initialValue = new Vector3(-16f, -1.1f, 0f);
    }

    private void Update()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(pauseMenu);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (SceneManager.GetActiveScene().name == "ParentsRoom" && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("House");
            
        }

        if (SceneManager.GetActiveScene().name == "KidsRoom" && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("House");

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
        } else 
        {
            Debug.Log("Unpause");
            Time.timeScale = 1;
            isGameOnPause = false;
            pauseMenu.SetActive(false);
        }
    }

    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }


    
}
