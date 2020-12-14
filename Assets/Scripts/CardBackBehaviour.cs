using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBackBehaviour : MonoBehaviour
{
    private SpriteManager SpriteManager = SpriteManager.instance;

    public void ClickBehaviour()
    {
        GameObject frontOfCard = transform.GetChild(0).gameObject;
        if (!frontOfCard.active)
        {
            frontOfCard.SetActive(true);
            CardFrontBehaviour cardFrontBehaviour = transform.GetChild(0).GetComponent<CardFrontBehaviour>();
            int spriteNumber = cardFrontBehaviour.getSpriteNumber();
            if (SpriteManager.hasNotSelectedFirst())
            {
                SpriteManager.setAsFirstSelected(spriteNumber, frontOfCard);
            }
            else if (SpriteManager.isHideable(spriteNumber))
            {
                StartCoroutine(SpriteManager.HideCoroutine(frontOfCard));
            }
        }
    }
}