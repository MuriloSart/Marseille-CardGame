using UnityEngine;

public class Discard : MonoBehaviour
{
    public virtual void ToDeck(Deck origin, Deck destiny, CardBase card, bool animation = true)
    {
        destiny.cards.Add(card);
        if(animation) card.SlideTo(destiny);
        origin.cards.Remove(card);
    }
}
