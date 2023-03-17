using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParentsDoor : MonoBehaviour
{

    
    [SerializeField] bool isParentsRoomDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isParentsRoomDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isParentsRoomDoor = false;
    }

    private void Update()
    {
        if(isParentsRoomDoor && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(4);
        }
    }
}