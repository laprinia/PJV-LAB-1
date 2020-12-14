using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CardInstantiator : MonoBehaviour
{
    private ArrayList _backArrayList = new ArrayList();
    private int xOffset;
    private int yOffset;
    public int xPace = 150;
    public int yPace = 300;
    public Transform cardsTransform;
    public GameObject cardFront;
    public GameObject cardBack;

    void Start()
    {
        AddCardBacks();
        AddCardFronts();
        Destroy(cardBack);
    }

    public void AddCardFronts()
    {
        int[] shuffledPositions = CardIndexShuffler.getShuffledIndices();
        int i = 0;
        foreach (GameObject backCard in _backArrayList)
        {
            if (backCard.transform.childCount > 0)
            {
                Destroy(backCard.transform.GetChild(0).gameObject);
            }

            GameObject frontCard = Instantiate(cardFront, backCard.transform.position, Quaternion.identity,
                backCard.transform);
            frontCard.GetComponent<CardFrontBehaviour>().setSprite(shuffledPositions[i]);
            frontCard.SetActive(false);
            i++;
        }

        GameManager.instance.ResetGame();
    }

    void AddCardBacks()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject back = Instantiate(cardBack,
                    cardBack.transform.position + transform.right * xOffset + transform.up * yOffset,
                    Quaternion.identity,
                    cardsTransform);
                xOffset += xPace;
                _backArrayList.Add(back);
            }
            yOffset += yPace;
            xOffset = 0;
        }
    }
}