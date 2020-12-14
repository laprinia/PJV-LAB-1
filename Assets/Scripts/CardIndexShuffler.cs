using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardIndexShuffler : MonoBehaviour
{
    private static int[] cardIndices = {0, 0, 1, 1, 2, 2, 3, 3};
    
    public static int[] getShuffledIndices()
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
}
