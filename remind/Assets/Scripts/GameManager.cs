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
    [SerializeField] Scene houseScene;  

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

    private void Start()
    {
        Instantiate(playerPrefab, spawners[0].transform.position, Quaternion.identity);
    }
    private void Update()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(pauseMenu);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }


        if(SceneManager.GetActiveScene().buildIndex == 4 && Input.GetKeyDown(KeyCode.Q))
        {
            
            SceneManager.LoadScene(2);
            

        }
    }

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



   /* public void ParentsRoomDoor()
    {
        SceneManager.LoadScene(4);
       
    } */
    
}