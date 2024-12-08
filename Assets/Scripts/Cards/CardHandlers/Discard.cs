using UnityEngine;

public class Discard : MonoBehaviour
{
    public void ToDeck(Deck origin, Deck destiny, CardBase card)
    {
        destiny.cards.Add(card);
        card.SlideTo(destiny);
        origin.cards.Remove(card);
    }
}
