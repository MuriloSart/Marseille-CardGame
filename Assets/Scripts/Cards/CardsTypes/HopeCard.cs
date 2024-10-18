using UnityEngine;

public class HopeCard : CardBase
{
    private readonly IAbilityCard _ability;

    public HopeCard()
    {
        _ability = new HopeAbility();
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
