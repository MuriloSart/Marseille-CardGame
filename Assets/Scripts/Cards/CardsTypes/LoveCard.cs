using UnityEngine;

public class LoveCard : CardBase
{
    private readonly IAbilityCard _ability;

    public LoveCard()
    {
        _ability = new LoveAbility();
    }

    public override Sprite Render()
    {
        return _ability.Render();
    }

    public override void AttackAbility()
    {
        _ability.ExecuteAttackAbility(Owner, Owner.enemy, dmg);
    }

    public override void DefenseAbility()
    {
        _ability.ExecuteDefenseAbility(Owner, Owner.enemy, dmg);
    }

}
