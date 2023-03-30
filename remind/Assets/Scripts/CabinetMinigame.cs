using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CabinetMinigame : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects; //prefabs

    [SerializeField] private List<GameObject> randomList;

    [SerializeField] int maxRandomArray = 10;

    [SerializeField] GameObject currentObject;

    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject gameManager;

   
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        randomList = RandomSequence(gameObjects);
        InstantiateNewObject();
    }

    void Update()
    {
        if(randomList.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PinkCloset();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                BlueCloset();
            }
        }
        
    }

    List<GameObject> RandomSequence(GameObject[] gameObjects)
    {
        List<GameObject> randomList = new List<GameObject>();
        for (int i = 0; i < maxRandomArray; i++)
        {
            randomList.Add(gameObjects[Random.Range(0, gameObjects.Length)]);
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
            
            //Time.timeScale = 0;
            winScreen.SetActive(true);
            
        }

    }

    public void BlueCloset()
    {
        if (GameObject.FindGameObjectWithTag("BlueClothes"))
        {
            if (currentObject.GetComponent<BlueClothes>() != null)
            {
                currentObject.GetComponent<BlueClothes>().ClothAnimation();
            }
            Destroy(currentObject, 1f);
            if(randomList.Count != 0)
            {
                randomList.RemoveAt(0);
            }
            
            InstantiateNewObject();
        }
        else
        {
            Debug.Log("WRONG CABINET");
        }
    }

    public void PinkCloset()
    {
        if (GameObject.FindGameObjectWithTag("PinkClothes"))
        {
            if (currentObject.GetComponent<PinkClothes>() != null)
            {
                currentObject.GetComponent<PinkClothes>().ClothAnimation();
            }
            Destroy(currentObject, 1f);

            if (randomList.Count != 0)
            {
                randomList.RemoveAt(0);
            }
            InstantiateNewObject();
        }
        else
        {
            Debug.Log("WRONG CABINET");
        }
    }

    public void ExitButton()
    {
        gameManager.GetComponent<GameManager>().isCabinetMinigameCompleted = true;
        SceneManager.LoadScene(5);
    }
}


