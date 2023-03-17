using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KidsRoomDoor : MonoBehaviour
{

    
    [SerializeField] bool isKidsRoomDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isKidsRoomDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isKidsRoomDoor = false;
    }

    private void Update()
    {
        if (isKidsRoomDoor && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(5);
        }
    }
}
