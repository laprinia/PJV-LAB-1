using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpriteManager : MonoBehaviour
{
    
    private static int firstNumber;
    private static GameObject firstObject;
    private static int parameterCount = 0;
    private  static int[] positions = {0, 0, 1, 1, 2, 2, 3, 3};
    
    public static int[] getShuffledPositions()
    {
        int[] newPositions = positions.Clone() as int[];
        for (int i = 0; i < newPositions.Length; i++)
        {
            int temp = newPositions[i];
            int r = Random.Range(i, newPositions.Length);
            newPositions[i] = newPositions[r];
            newPositions[r] = temp;
        }

        return newPositions;
    }

    public static bool isHideable(int spriteNumber, GameObject first)
    {
        
        parameterCount++;
        if (parameterCount > 2)
        {
            return true;
        }
        if (parameterCount == 2 && spriteNumber != firstNumber)
        {
            firstObject.SetActive(false);
            parameterCount = 0;
            return true;
        }
        if (parameterCount == 2 & spriteNumber == firstNumber)
        {
            parameterCount = 0;
            IncrementScore();
            Debug.Log("score imcrem");
            return false;
        }
        if (parameterCount == 1)
        {
            firstNumber = spriteNumber;
            firstObject = first;
        }

        return false;
    }

    
    public static IEnumerator HideCoroutine(GameObject cardToHide)
    {
        yield return new WaitForSeconds(1);
        cardToHide.SetActive(false);
    }
    public static void IncrementScore()
    {
        
    }
}