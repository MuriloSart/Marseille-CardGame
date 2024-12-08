using UnityEngine;

public interface IAbilityCard
{
    public EffectBase ExecuteAttackAbility(Entity player, Entity enemy, int cardValue);

    public EffectBase ExecuteDefenseAbility(Entity entity, Entity enemy, int cardValue);

    public Sprite Render();
}
