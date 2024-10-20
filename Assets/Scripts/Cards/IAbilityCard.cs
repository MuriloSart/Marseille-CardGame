using UnityEngine;

public interface IAbilityCard
{
    public void ExecuteAttackAbility(Entity player, Entity enemy, int amount);

    public void ExecuteDefenseAbility(Entity entity, Entity enemy, int amount);

    public Sprite Render();
}
