using UnityEngine;

public class TurnResult : MonoBehaviour
{
    public void DamageTurn(Entity entity, int damage)
    {
        if (entity.selectedCards.cards.Count == 0 || entity.selectedCards == null) return;

        entity.selectedCards.cards[0].damageType.Deal(entity, damage);
    }
}
