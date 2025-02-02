public class DiscardOnHand : Discard
{
    public override void ToDeck(Deck origin, Deck destiny, CardBase card, bool animation = true)
    {
        base.ToDeck(origin, destiny, card, animation);
        card.transform.SetParent(destiny.transform);
    }
}
