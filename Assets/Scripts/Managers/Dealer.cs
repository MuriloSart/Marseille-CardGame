using Cards.CardHandlers.DealCard;
using UnityEngine;

public class Dealer : Singleton<Dealer>
{
    public int durationAnimation = 1;

    private int _currentBattle = 0;

    [SerializeField] private DealCard deal;

    public DealCard Deal { get => deal; }

    public int FillHands(Entity player, Entity enemy)
    {
        FillHand(player, player.drawPile);
        FillHand(enemy, enemy.drawPile);

        if (_currentBattle == 0) _currentBattle = 1;
        else if (_currentBattle == 1) _currentBattle = 0;

        return _currentBattle;
    }

    private void FillHand(Entity entity, DrawPile drawPile)
    {
        int amountDealing = GlobalVariables.MaxCardNumber - entity.cardsOnHand.cards.Count;

        for (int i = 0; i < amountDealing; i++)
        {
            deal.ToEntity(entity, drawPile);
        }
    }
}
