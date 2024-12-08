using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour 
{
    public List<CardBase> cards;
    public Discard discard;

    public void DiscardTo(Deck destiny, CardBase card)
    {
        discard.ToDeck(this, destiny, card);
    }
}
