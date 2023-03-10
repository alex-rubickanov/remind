using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DishWashingMinigame : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;//prefabs

    [SerializeField] private List<GameObject> randomList;

    [SerializeField] int maxRandomArray = 10;
    
    [SerializeField] GameObject currentObject;

    [Header("BUTTONS AND WIN SCREEN")]
    [SerializeField] Button plateButton;
    [SerializeField] Button spoonButton;
    [SerializeField] Button forkButton;
    [SerializeField] GameObject winScreen;
    void Start()
    {
        randomList = RandomSequence(gameObjects);
        InstantiateNewObject();
    }

    void Update()
    {
       
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

    void InstantiateNewObject()
    {
        //currentObject = Instantiate(randomArray[0]);
        if (randomList.Count >= 1)
        {
            currentObject = Instantiate(randomList[0]);
        }
        else 
        {
            Debug.Log("PLAYER WON"); 
            forkButton.enabled = false;
            spoonButton.enabled = false;
            plateButton.enabled = false;
            winScreen.SetActive(true);
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
        }
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
}
