using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtonBehaviour : MonoBehaviour
{
    public void ClickBehaviour()
    {
        GameObject cardDeck = GameObject.FindWithTag("Card Deck");
        cardDeck.GetComponent<CardInstantiator>().AddCardFronts();
    }
}