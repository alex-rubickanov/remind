using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndCutsceneScript : MonoBehaviour
{
    VideoPlayer player;
    bool once = true;

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
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
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
