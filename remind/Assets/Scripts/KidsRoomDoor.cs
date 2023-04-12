using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KidsRoomDoor : MonoBehaviour
{
    [SerializeField] VectorValue pastPos;
    

    [SerializeField] bool isKidsRoomDoor = false;
    [SerializeField] Player player;

    GameObject kidsRoomExitIcon;

    private void Start()
    {
        kidsRoomExitIcon = GameObject.Find("KidsRoomExitIcon");
        kidsRoomExitIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Kids Room Trigger Enter");
        isKidsRoomDoor = true;
        kidsRoomExitIcon.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Kids Room Trigger Exit");
        isKidsRoomDoor = false;
        kidsRoomExitIcon.SetActive(false);
    }

    private void Update()
    {
        
        if (isKidsRoomDoor && Input.GetKeyDown(KeyCode.E))
        {
            pastPos.initialValue = player.gameObject.transform.position;
            SceneManager.LoadScene("KidsRoom");
        }
    }
}
