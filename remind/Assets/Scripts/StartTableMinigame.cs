using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTableMinigame : MonoBehaviour
{
     bool isTableTrigger = false;
     [SerializeField] VectorValue pastPos;
     GameObject player;
     GameObject gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTableTrigger = true;
        Debug.Log("Enter Table Trigger");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTableTrigger = false;
        Debug.Log("Exit Table Trigger");
    }

    public void StartMinigame()
    {

        SceneManager.LoadScene(8);
    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Althea");
    }

    private void Update()
    {
        if (gameManager.GetComponent<GameManager>().isTableMinigameCompleted == false)
        {
            if (isTableTrigger == true && Input.GetKeyDown(KeyCode.F))
            {
                pastPos.initialValue = new Vector3(13.41f, -1.1f, 0);
                gameManager.GetComponent<GameManager>().index.index = 8;
                StartMinigame();
            }
        }
    }
}
