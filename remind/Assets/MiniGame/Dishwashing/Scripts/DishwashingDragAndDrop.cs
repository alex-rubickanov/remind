using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DishwashingDragAndDrop : MonoBehaviour
{
    [SerializeField] private GameObject correctPosition;

    private bool movingPlate;
    private bool plateCorrect;

    private float startPosX;
    private float startPosY;

    private int wrongMoveCounter = 0;

    private Vector2 resetPosition;

    DishWashingMinigame minigameScript;

    GameObject gameManager;


    void Start()
    {
        resetPosition = this.transform.localPosition;
        gameManager = GameObject.Find("GameManager");
        CheckCorrectPosition();
        minigameScript = Camera.main.GetComponent<DishWashingMinigame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (plateCorrect == false)
        {
            if (movingPlate)
            {
                Vector2 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
            }
        }
    }

    private void OnMouseDown()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                startPosX = mousePos.x - this.transform.localPosition.x;
                startPosY = mousePos.y - this.transform.localPosition.y;

                movingPlate = true;
            }
        }

    }

    private void OnMouseUp()
    {
        movingPlate = false;
        if (Time.timeScale != 0)
        {
            if (Mathf.Abs(this.transform.localPosition.x - correctPosition.transform.localPosition.x) <= 4f && Mathf.Abs(this.transform.localPosition.y - correctPosition.transform.localPosition.y) <= 4f)
            {
                this.transform.localPosition = new Vector2(correctPosition.transform.localPosition.x, correctPosition.transform.localPosition.y);

                plateCorrect = true;

                Destroy(gameObject);

                minigameScript.randomList.RemoveAt(0);

                minigameScript.InstantiateNewObject();

            }
            else
            {
                this.transform.localPosition = new Vector2(resetPosition.x, resetPosition.y);
                wrongMoveCounter += 1;

                if (wrongMoveCounter == 2)
                {
                    SceneManager.LoadScene(7);
                }
            }
        }

    }

    private void CheckCorrectPosition()
    {
        if (this.gameObject.tag == "Fork") correctPosition = GameObject.Find("Forks");
        else if (this.gameObject.tag == "Spoon") correctPosition = GameObject.Find("Spoons");
        else correctPosition = GameObject.Find("Plates");
    }


    public void ExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("House");
    }
}
