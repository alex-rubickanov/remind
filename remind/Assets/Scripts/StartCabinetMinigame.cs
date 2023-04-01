using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCabinetMinigame : MonoBehaviour
{
    bool isCabinetTrigger = false;
    
    [SerializeField] GameObject player;
    GameObject gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCabinetTrigger = true;
        Debug.Log("Enter Cabinet Trigger");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCabinetTrigger = false;
        Debug.Log("Exit Cabinet Trigger");
    }

    public void StartMinigame()
    {

        SceneManager.LoadScene(6);
    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    private void Update()
    {
        if (gameManager.GetComponent<GameManager>().isCabinetMinigameCompleted == false)
        {
            if (isCabinetTrigger == true && Input.GetKeyDown(KeyCode.F))
            {
                gameManager.GetComponent<GameManager>().index.index = 6;
                StartMinigame();
            }
        }
    }
}
