using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsRoomExit : MonoBehaviour
{
    GameManager gameManager;
    GameObject exitIcon;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        exitIcon = GameObject.Find("ExitIcon"); ;
        exitIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        exitIcon.SetActive(true);
        gameManager.isParentsRoomExitTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitIcon.SetActive(false);  
        gameManager.isParentsRoomExitTrigger = false;
    }
}
