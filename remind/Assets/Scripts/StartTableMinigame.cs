using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTableMinigame : MonoBehaviour
{
    GameObject dinnerIcon;
     bool isTableTrigger = false;
     [SerializeField] VectorValue pastPos;
     GameObject player;
     GameObject gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTableTrigger = true;
        Debug.Log("Enter Table Trigger");

        if (dinnerIcon != null)
        {
            dinnerIcon.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTableTrigger = false;
        Debug.Log("Exit Table Trigger");

        if (dinnerIcon != null)
        {
            dinnerIcon.SetActive(false);
        }
        
    }

    public void StartMinigame()
    {

        SceneManager.LoadScene(8);
    }

    private void Start()
    {
        dinnerIcon = GameObject.Find("DinnerIcon");
        dinnerIcon.SetActive(false);
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
