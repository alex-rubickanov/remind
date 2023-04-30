using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndCutsceneScript1 : MonoBehaviour
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
                gameManager.isSecondCutsceneEnd = true;
                SceneManager.LoadScene("MainMenu");
                
            }
        }
    }
}
