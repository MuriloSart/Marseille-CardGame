using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour 
{
    public List<CardBase> cards;
    public Discard discard;

    public virtual void DiscardTo(Deck destiny, CardBase card, bool animation = true)
    {
        discard.ToDeck(this, destiny, card, animation);
    }
}
