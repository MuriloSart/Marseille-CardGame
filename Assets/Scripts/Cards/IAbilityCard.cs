using UnityEngine;

public interface IAbilityCard
{
    public void ExecuteAttackAbility(Entity player, Entity enemy, int cardValue);

    public void ExecuteDefenseAbility(Entity entity, Entity enemy, int cardValue);

    public Sprite Render();
}
