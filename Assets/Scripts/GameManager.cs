using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpriteManager : MonoBehaviour
{
    private int gameScore;
    public Text scoreText;
    public static SpriteManager instance;
    private static int firstCardNumber;
    private static GameObject firstCardGameObject;
    private static int parameterCount = 0;
    private static int[] cardIndices = {0, 0, 1, 1, 2, 2, 3, 3};

    void Awake()
    {
        instance = this;
    }

    public int[] getShuffledCards()
    {
        int[] newPositions = cardIndices.Clone() as int[];
        for (int i = 0; i < newPositions.Length; i++)
        {
            int temp = newPositions[i];
            int r = Random.Range(i, newPositions.Length);
            newPositions[i] = newPositions[r];
            newPositions[r] = temp;
        }
        return newPositions;
    }

    public bool hasNotSelectedFirst()
    {
        return parameterCount == 0;
    }

    public void setAsFirstSelected(int firstNumber, GameObject firstCard)
    {
        firstCardGameObject = firstCard;
        firstCardNumber = firstNumber;
        parameterCount++;
    }


    public bool isHideable(int currentCardNumber)
    {
        parameterCount++;
        if (parameterCount > 2)
        {
            return true;
        }

        if (parameterCount == 2 && currentCardNumber != firstCardNumber)
        {
            StartCoroutine(HideCoroutine(firstCardGameObject));
            parameterCount = 0;
            return true;
        }

        if (parameterCount == 2 & currentCardNumber == firstCardNumber)
        {
            parameterCount = 0;
            IncrementScore();
            return false;
        }
        return false;
    }


    public IEnumerator HideCoroutine(GameObject cardToHide)
    {
        yield return new WaitForSeconds(1);
        cardToHide.SetActive(false);
    }

    public void IncrementScore()
    {
        gameScore+=10;
        scoreText.text ="SCORE: " + gameScore;
    }
}