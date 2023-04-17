using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParentsDoor : MonoBehaviour
{
    GameObject parentroomicon;
    [SerializeField] VectorValue pastPos;

    [SerializeField] bool isParentsRoomDoor = false;
    [SerializeField] Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Parents Room Trigger Enter");
        isParentsRoomDoor = true;
        parentroomicon.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Parents Room Trigger Exit");
        isParentsRoomDoor = false;
        parentroomicon.SetActive(false);
    }
    private void Start()
    {
        parentroomicon = GameObject.Find("ParentRoomIcon");
        parentroomicon.SetActive(false);
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
