using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPositionWhenAspect : MonoBehaviour
{
    GameManager gameManager;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager.isAnnaAspect)
        {
            if (gameObject.name == "Plates")
            {
                
                gameObject.transform.position = new Vector3(-5.35f, transform.position.y, transform.position.z);
            } else if(gameObject.name == "Forks")
            {
                gameObject.transform.position = new Vector3(5.72f, transform.position.y, transform.position.z);
            } else
            {
                gameObject.transform.position = new Vector3(-5.72f, transform.position.y, transform.position.z);
            }
        }
        
    }
}
