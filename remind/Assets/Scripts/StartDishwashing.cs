using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartDishwashing : MonoBehaviour
{

    bool isSinkTrigger = false;
    [SerializeField] VectorValue pastPos;
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isSinkTrigger = true;
        Debug.Log("Enter Sink Trigger");
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isSinkTrigger = false;
        Debug.Log("Exit Sink Trigger");
    }

    public void StartMinigame()
    {
        
        SceneManager.LoadScene(4);
    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    private void Update()
    {
        if(gameManager.GetComponent<GameManager>().isDishwashingCompleted == false)
        {
            if (isSinkTrigger == true && Input.GetKeyDown(KeyCode.F))
            {
                pastPos.initialValue = new Vector3(8.5f, -1.1f, 0);
                gameManager.GetComponent<GameManager>().index.index = 4;
                StartMinigame();
            }
        }
    }
}