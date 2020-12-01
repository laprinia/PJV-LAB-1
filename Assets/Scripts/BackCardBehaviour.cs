using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateFront : MonoBehaviour
{
    public GameObject cardFront;
    public Sprite randomSprite;

    private void Awake()
    {
        Debug.Log(this.GetInstanceID()+" is awake.");
    }

    private void Start()
    {
        
    }

    private void generateFront()
    {
        
        cardFront.GetComponent<Image>().sprite = randomSprite;
        
    }

    private void OnDestroy()
    {
      
    }
}
