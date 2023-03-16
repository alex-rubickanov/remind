using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsDoor : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Player can enter the parents room");
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Pressed F");
            gameManager.ParentsRoomDoor();
        }
    }

}
