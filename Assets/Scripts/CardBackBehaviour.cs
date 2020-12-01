using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBackBehaviour : MonoBehaviour
{

    public void ClickBehaviour()
    {
        if (!transform.GetChild(0).gameObject.active)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            CardFrontBehaviour cardFrontBehaviour = transform.GetChild(0).GetComponent<CardFrontBehaviour>();
            int spriteNumber = cardFrontBehaviour.getSpriteNumber();
            if (SpriteManager.isHideable(spriteNumber, transform.GetChild(0).gameObject))
            {
                StartCoroutine(SpriteManager.HideCoroutine(transform.GetChild(0).gameObject));
            }
        }
    }


}
