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

    //[Header("BUTTONS AND WIN SCREEN")]
    //[SerializeField] GameObject winScreen;
    void Start()
    {
        randomList = RandomSequence(gameObjects);
        InstantiateNewObject();
    }

    void Update()
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
            //winScreen.SetActive(true);
        }

    }

    public void BlueCloset()
    {
        if (GameObject.FindGameObjectWithTag("BlueClothes"))
        {
            currentObject.GetComponent<BlueClothes>().ClothAnimation();
            Destroy(currentObject, 1f);
            randomList.RemoveAt(0);
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
            currentObject.GetComponent<PinkClothes>().ClothAnimation();
            Destroy(currentObject, 1f);
            randomList.RemoveAt(0);
            InstantiateNewObject();
        }
        else
        {
            Debug.Log("WRONG CABINET");
        }
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
}


