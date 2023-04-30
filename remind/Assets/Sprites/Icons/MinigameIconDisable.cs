using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameIconDisable : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gameObject.name == "DinnerIcon" && gameManager.isTableMinigameCompleted)
        {
            Destroy(gameObject);

        } else if (gameObject.name == "DishwashingMinigameIcon" && gameManager.isDishwashingCompleted)
        {
            Destroy(gameObject);

        } else if (gameObject.name == "CabinetMinigameIcon" && gameManager.isCabinetMinigameCompleted)
        {
            Destroy(gameObject);

        }
    }
}
