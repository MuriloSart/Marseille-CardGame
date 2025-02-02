using Cards.CardHandlers.DealCard;
using UnityEngine;

public class Dealer : Singleton<Dealer>
{
    public int durationAnimation = 1;

    [SerializeField] private DealCard deal;

    public DealCard Deal { get => deal; }

    public int FillHands(Entity player, Entity enemy, int currentBattle)
    {
        FillHand(player, player.drawPile);
        FillHand(enemy, enemy.drawPile);

        if (currentBattle == 0) currentBattle = 1;
        else if (currentBattle == 1) currentBattle = 0;

        return currentBattle;
    }

    private void FillHand(Entity entity, DrawPile drawPile)
    {
        int amountDealing = GlobalVariables.MaxCardNumber - entity.cardsOnHand.cards.Count;

        for (int i = 0; i < amountDealing; i++)
        {
            deal.ToEntity(entity, drawPile);
        }
        entity.AcquireCards();
    }
}
