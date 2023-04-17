using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    float timer = 3;

    [SerializeField] private GameObject[] jumpscare;
    [SerializeField] private GameObject[] jumpscareSounds;

    [SerializeField] PreviousScene index;

    GameObject currentJumpscare;
    GameObject currentJumpscareSounds;

    [SerializeField] float speed = 2f;
    Vector3 newScale = new Vector3(1.2f, 1.2f, 1.2f);
    Vector3 endScale = new Vector3(-0.7f, -0.7f, -0.7f);

    GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentJumpscare = InstantiateNewObject(); ;
        currentJumpscareSounds = InstantiateNewSound();

        gameManager.jumpscareCount++;
    }

    void Update()
    {

        currentJumpscare.transform.localScale = Vector3.Lerp(currentJumpscare.transform.localScale, newScale, speed * Time.deltaTime);
        timer -= Time.deltaTime;
        Debug.Log(timer);

        if(timer <= 1f)
        {
            currentJumpscare.transform.localScale = Vector3.Lerp(currentJumpscare.transform.localScale, endScale, speed * Time.deltaTime);
        }

        

        if (timer <= 0)
        {
           SceneManager.LoadScene(index.index);
        }

        if(Time.timeScale == 0f)
        {
            currentJumpscareSounds.GetComponent<AudioSource>().Pause();
        } else
        {
            currentJumpscareSounds.GetComponent<AudioSource>().UnPause();
        }
    }
    GameObject InstantiateNewObject()
    {
       return Instantiate(jumpscare[Random.Range(0, 7)]);

    }
    GameObject InstantiateNewSound()
    {
        return Instantiate(jumpscareSounds[Random.Range(0, 5)]);


    }
}
