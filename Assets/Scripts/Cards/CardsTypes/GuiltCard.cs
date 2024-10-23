using UnityEngine;

public class GuiltCard : CardBase
{
    private IAbilityCard _ability;

    public GuiltCard(int dmg) : base(dmg)
    {
        _ability = new GuiltAbility();
    }

    public override Sprite Render()
    {
        return _ability.Render();
    }

    public override void AttackAbility()
    {
        _ability.ExecuteAttackAbility(Owner, Owner.enemy, Damage);
    }

    public override void DefenseAbility()
    {
        _ability.ExecuteDefenseAbility(Owner, Owner.enemy, Damage);
    }
}
