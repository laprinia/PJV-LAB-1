using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CardInstantiator : MonoBehaviour
{
    private ArrayList _backArrayList = new ArrayList();
    private int xOffset = 0;
    private int yOffset = 0;
    public int xPace = 150;
    public int yPace = 300;
    public Transform cardsTransform;
    public GameObject cardFront;
    public GameObject cardBack;

    void Start()
    {
        AddCardBacks();
        Destroy(cardBack);
        int[] shuffledPositions = SpriteManager.instance.getShuffledCards();
        int i = 0;
        foreach (GameObject backCard in _backArrayList)
        {
            GameObject frontCard = Instantiate(cardFront, backCard.transform.position, Quaternion.identity,
                backCard.transform);
            frontCard.GetComponent<CardFrontBehaviour>().setSprite(shuffledPositions[i]);
            i++;
            frontCard.SetActive(false);
        }
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