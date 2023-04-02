using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FridgeNotes : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    bool isFridgeNotesTrigger = false;
    [SerializeField] GameObject fridgeNotes;
    bool isFridgeNotesEnabled = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter fridge notes trigger");
        isFridgeNotesTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit fridge notes trigger");
        isFridgeNotesTrigger = false;
    }

    private void Update()
    {
        if(isFridgeNotesTrigger && Input.GetKeyDown(KeyCode.F))
        {
            ShowNotes();
        }
    }

    public void ShowNotes()
    {
        if (isFridgeNotesEnabled == false)
        {
            Debug.Log("Show notes");
            Time.timeScale = 0;

            isFridgeNotesEnabled = true;
            fridgeNotes.SetActive(true);
        }
        else
        {
            Debug.Log("Hide notes");
            Time.timeScale = 1;

            isFridgeNotesEnabled = false;
            fridgeNotes.SetActive(false);
        }
    }

}
