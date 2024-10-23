using UnityEngine;

public class HopeCard : CardBase
{
    private readonly IAbilityCard _ability;

    public HopeCard(int dmg) : base(dmg)
    {
        _ability = new HopeAbility();
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
