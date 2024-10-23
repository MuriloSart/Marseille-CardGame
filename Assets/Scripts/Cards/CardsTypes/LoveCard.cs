using UnityEngine;

public class LoveCard : CardBase
{
    private readonly IAbilityCard _ability;

    public LoveCard(int dmg) : base(dmg)
    {
        _ability = new LoveAbility();
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
