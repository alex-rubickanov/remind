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

    [Header("BUTTONS AND WIN SCREEN")]
    [SerializeField] GameObject winScreen;
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
            winScreen.SetActive(true);
        }

    }

    public void BlueCloset()
    {
        if (GameObject.FindGameObjectWithTag("BlueClothes"))
        {
            StartCoroutine(ClothesAnimation(currentObject, 1f));
            
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
            Destroy(currentObject);
            randomList.RemoveAt(0);
            InstantiateNewObject();
        }
        else
        {
            Debug.Log("WRONG CABINET");
        }
    }

    IEnumerator ClothesAnimation(GameObject gameObject, float time)
    {
        if(gameObject.tag == "PinkClothes")
        {
            Vector3 startingPos = gameObject.transform.position;
            Vector3 finalPos = gameObject.transform.position + (-gameObject.transform.right * 4);
            float elapsedTime = 0;

            while (elapsedTime < time)
            {
                gameObject.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
                elapsedTime += Time.deltaTime;
                    
            }
        }

        if(gameObject.tag == "BlueClothes")
        {
            Vector3 startingPos = gameObject.transform.position;
            Vector3 finalPos = gameObject.transform.position + (gameObject.transform.right * 4);
            float elapsedTime = 0;

            while (elapsedTime < time)
            {
                gameObject.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
                elapsedTime += Time.deltaTime;

            }
        }
        randomList.RemoveAt(0);
        InstantiateNewObject();
        Destroy(gameObject);
        yield return null;
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
}


