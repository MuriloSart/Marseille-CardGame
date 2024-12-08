using UnityEngine;

namespace Cards.CardHandlers.DealCard
{
    public class DealCard : MonoBehaviour
    {
        public void ToEntity(Entity entity, DrawPile drawPile)
        {
            if (entity.cardsOnHand.cards.Count >= GlobalVariables.MaxCardNumber) return;

            int index = Random.Range(0, drawPile.cards.Count);

            drawPile.DiscardTo(entity.cardsOnHand, drawPile.cards[index]);

            entity.AcquiringCards();
        }
    }
}

