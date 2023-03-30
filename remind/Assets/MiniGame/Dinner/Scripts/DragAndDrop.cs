using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject correctPosition;
    private bool movingPlate;
    private float startPosX;
    private float startPosY;
    private Vector2 resetPosition;

    
    [SerializeField] GameObject nextPlate;


    void Start()
    {
        resetPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingPlate)
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }
    }

    private void OnMouseDown()
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

    private void OnMouseUp()
    {
        movingPlate = false;

        if (Mathf.Abs(this.transform.localPosition.x - correctPosition.transform.localPosition.x) <= 0.5f && Mathf.Abs(this.transform.localPosition.y - correctPosition.transform.localPosition.y) <= 0.5f)
        {
            this.transform.localPosition = new Vector2(correctPosition.transform.localPosition.x, correctPosition.transform.localPosition.y);
            
            if(nextPlate != null)
            {
                nextPlate.GetComponent<Collider2D>().enabled = true;
            }
            
        }
        else
        {
            this.transform.localPosition = new Vector2(resetPosition.x, resetPosition.y);
        }
    }
}
