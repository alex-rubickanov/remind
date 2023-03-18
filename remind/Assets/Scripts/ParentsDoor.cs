using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParentsDoor : MonoBehaviour
{
    
    [SerializeField] VectorValue pastPos;

    [SerializeField] bool isParentsRoomDoor = false;
    [SerializeField] Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Parents Room Trigger Enter");
        isParentsRoomDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Parents Room Trigger Exit");
        isParentsRoomDoor = false;
    }

    private void Update()
    {
        if(isParentsRoomDoor && Input.GetKeyDown(KeyCode.E))
        {
            pastPos.initialValue = player.gameObject.transform.position;
            SceneManager.LoadScene("ParentsRoom");
        }
    }
}
