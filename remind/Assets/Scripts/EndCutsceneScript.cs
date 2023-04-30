using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndCutsceneScript : MonoBehaviour
{
    VideoPlayer player;
    bool once = true;
    GameManager gameManager;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        player = GetComponent<VideoPlayer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(player.isPrepared)
        {
            if(once)
            {
                player.Play();
                once = false;
            }
            
            if(!player.isPlaying)
            {
                gameManager.isCabinetMinigameCompleted = false;
                gameManager.isDishwashingCompleted = false;
                gameManager.isTableMinigameCompleted = false;

                gameManager.isFirstCutsceneEnd = true;
                SceneManager.LoadScene("ParentsRoom");
            }
        }
    }
}
