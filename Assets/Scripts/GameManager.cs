using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private int gameScore;
    public Text scoreText;
    public static GameManager instance;
    private static int firstCardNumber;
    private static GameObject firstCardGameObject;
    private static int currentSelectionParameterCount;
    

    void Awake()
    {
        instance = this;
    }

    public void ResetGame()
    {
        gameScore = 0;
        scoreText.text = "SCORE: 0";
        currentSelectionParameterCount = 0;

    }

    

    public bool hasNotSelectedFirst()
    {
        return currentSelectionParameterCount == 0;
    }

    public void setAsFirstSelected(int firstNumber, GameObject firstCard)
    {
        firstCardGameObject = firstCard;
        firstCardNumber = firstNumber;
        currentSelectionParameterCount++;
    }


    public bool isHideable(int currentCardNumber)
    {
        currentSelectionParameterCount++;
        if (currentSelectionParameterCount > 2)
        {
            return true;
        }

        if (currentSelectionParameterCount == 2 && currentCardNumber != firstCardNumber)
        {
            StartCoroutine(HideCoroutine(firstCardGameObject));
            currentSelectionParameterCount = 0;
            if (gameScore > 0)
            {
                UpdateScore(-5);
            }
            
            return true;
        }

        if (currentSelectionParameterCount == 2 & currentCardNumber == firstCardNumber)
        {
            currentSelectionParameterCount = 0;
            UpdateScore(20);
            return false;
        }
        return false;
    }


    public IEnumerator HideCoroutine(GameObject cardToHide)
    {
        yield return new WaitForSeconds(1);
        cardToHide.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        gameScore+=score;
        scoreText.text ="SCORE: " + gameScore;
    }
}