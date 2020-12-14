using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBackBehaviour : MonoBehaviour
{
    private GameManager _gameManager = GameManager.instance;

    public void ClickBehaviour()
    {
        GameObject frontOfCard = transform.GetChild(0).gameObject;
        if (!frontOfCard.active)
        {
            frontOfCard.SetActive(true);
            CardFrontBehaviour cardFrontBehaviour = transform.GetChild(0).GetComponent<CardFrontBehaviour>();
            int spriteNumber = cardFrontBehaviour.getSpriteNumber();
            if (_gameManager.hasNotSelectedFirst())
            {
                _gameManager.setAsFirstSelected(spriteNumber, frontOfCard);
            }
            else if (_gameManager.isHideable(spriteNumber))
            {
                StartCoroutine(_gameManager.HideCoroutine(frontOfCard));
            }
        }
    }
}