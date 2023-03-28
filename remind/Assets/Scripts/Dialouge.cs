using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialouge : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    public float textspeed;
    private int index;
    [SerializeField] Player player;

    public bool finished = false;

    void Start()
    {
        //player.isAbleToInput = false;
        textcomponent.text = string.Empty;
        StartDialouge();
    }

    
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            if (textcomponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textcomponent.text = lines[index];
            }
        } 
    }
    void StartDialouge ()
    {
        index = 0;
        StartCoroutine(typeline());
    }

    IEnumerator typeline()
    {
        foreach (char c in lines[index]. ToCharArray()) 
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
    void NextLine()
    {
        if(index < lines.Length - 1) 
        {
            index++;
            textcomponent.text = string.Empty;
            StartCoroutine(typeline());
        }
        else
        {
            finished = true;
           // player.isAbleToInput = true;
            gameObject.SetActive(false);
            
        }
    }
}
