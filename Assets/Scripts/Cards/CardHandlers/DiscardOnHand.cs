public class DiscardOnHand : Discard
{
    public override void ToDeck(Deck origin, Deck destiny, CardBase card)
    {
        base.ToDeck(origin, destiny, card);
        card.transform.SetParent(destiny.transform);
    }
}
