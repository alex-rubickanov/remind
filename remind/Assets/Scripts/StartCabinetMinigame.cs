using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCabinetMinigame : MonoBehaviour
{
    GameObject cabinetIcon;
    bool isCabinetTrigger = false;
    
    [SerializeField] GameObject player;
    GameObject gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCabinetTrigger = true;
        Debug.Log("Enter Cabinet Trigger");
        cabinetIcon.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCabinetTrigger = false;
        Debug.Log("Exit Cabinet Trigger");
        cabinetIcon.SetActive(false);
    }

    public void StartMinigame()
    {

        SceneManager.LoadScene(6);
    }

    private void Start()
    {
        cabinetIcon = GameObject.Find("CabinetMiniGameIcon");
        cabinetIcon.SetActive(false);
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
