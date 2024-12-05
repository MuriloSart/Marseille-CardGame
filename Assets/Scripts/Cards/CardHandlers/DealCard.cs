using UnityEngine;

public class DealCard : Singleton<DealCard>
{
    private int _currentBattle = 0;

    private readonly int maxCardNumber = 7;
    public int MaxCardNumber { get => maxCardNumber; }

    public int ToResetRound(Entity player, Entity enemy, Deck pack)
    {
        int amountDealing = maxCardNumber - player.cardsOnHand.Count;
        for (int i = 0; i < amountDealing * 2; i+=2)
        {
            ToEntity(player, pack);
            ToEntity(enemy, pack);    
        }

        if (_currentBattle == 0)
            _currentBattle = 1;
        else if (_currentBattle == 1)
            _currentBattle = 0;

        return _currentBattle;
    }

    public void ToEntity(Entity player, Deck pack)
    {
        if (player.cardsOnHand.Count >= maxCardNumber) return;
        int index = Random.Range(0, pack.cards.Count);
        player.cardsOnHand.Add(pack.cards[index]);
        pack.cards.RemoveAt(index);
        player.AcquiringCards();
    }
}
