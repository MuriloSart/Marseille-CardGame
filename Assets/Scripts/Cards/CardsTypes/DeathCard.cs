using UnityEngine;

public class DeathCard : CardBase
{
    private IAbilityCard _ability;

    public DeathCard()
    {
        _ability = new DeathAbility();
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
