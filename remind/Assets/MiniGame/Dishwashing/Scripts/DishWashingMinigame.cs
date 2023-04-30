using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DishWashingMinigame : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects; //prefabs

    [SerializeField] public List<GameObject> randomList;

    [SerializeField] int maxRandomArray = 10;
    
    [SerializeField] GameObject currentObject;
    [SerializeField] GameObject gameManager;

    int mistakes = 0;

    float timer = 0f;
    int randomNumber = 2;

    [Header("BUTTONS AND WIN SCREEN")]
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject[] buttons;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager");   
        randomList = RandomSequence(gameObjects);
        InstantiateNewObject();
    }

    void Update()
    {
       if (mistakes >= 2)
        {
            SceneManager.LoadScene("Jumpscare");
        }
        
    }

    List<GameObject> RandomSequence(GameObject[] gameObjects)
    {
        List<GameObject> randomList = new List<GameObject>();
        for (int i = 0; i < maxRandomArray; i++)
        {
            randomList.Add(gameObjects[Random.Range(0,gameObjects.Length)]);
        }

        return randomList;
    }

    public void InstantiateNewObject()
    {
        //currentObject = Instantiate(randomArray[0]);
        if (randomList.Count >= 1)
        {
            currentObject = Instantiate(randomList[0]);
        }
        else 
        {
            Debug.Log("PLAYER WON"); 
            Time.timeScale = 0;
            winScreen.SetActive(true);
            gameManager.GetComponent<GameManager>().isDishwashingCompleted = true;
        }
        
    }
    
    public void PlateButton()
    {
        if (GameObject.FindGameObjectWithTag("Plate"))
        {
            Destroy(currentObject);
            randomList.RemoveAt(0);
            InstantiateNewObject();
        } else
        {
            Debug.Log("WRONG SHELF");
            mistakes++;
        }
    }

    public void SpoonButton()
    {
        if (GameObject.FindGameObjectWithTag("Spoon"))
        {
            Destroy(currentObject);
            randomList.RemoveAt(0);
            InstantiateNewObject();
        }
        else
        {
            Debug.Log("WRONG SHELF");
            mistakes++;
        }
    }

    public void ForkButton()
    {
        if (GameObject.FindGameObjectWithTag("Fork"))
        {
            Destroy(currentObject);
            randomList.RemoveAt(0);
            InstantiateNewObject();
        }
        else
        {
            Debug.Log("WRONG SHELF");
            mistakes++;
        }
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("House");
    }

    public void Swap() {
        Debug.Log("Swap");
        Vector3 bridge = buttons[0].transform.position;
        for(int i = 0; i < buttons.Length - 1; i++) {
            buttons[i].transform.position = buttons[i+1].transform.position;
        }
        buttons[2].transform.position = bridge;
    }

    public void RandomSwap() 
    {
        if(timer <= randomNumber) {
            timer += Time.deltaTime;
            Debug.Log((int)timer);
        } else {
            Swap();
            randomNumber = Random.Range(1, 3);
            Debug.Log("Random number is " + randomNumber + "!!!!!!!!!!");
            timer = 0f;
        }
        
    }
}
