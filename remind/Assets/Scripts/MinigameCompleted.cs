using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameCompleted : MonoBehaviour
{
    GameManager gameManager;
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if  (gameManager != null)
        {
            if(gameManager.isCabinetMinigameCompleted == true)
            {
                gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
            }
        }
    }
}
