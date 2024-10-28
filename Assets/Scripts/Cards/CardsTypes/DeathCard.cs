using UnityEngine;

public class DeathCard : CardBase
{
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
        _effect = _ability.ExecuteAttackAbility(Owner, Owner.enemy, Damage);
    }

    public override void DefenseAbility()
    {
        _effect = _ability.ExecuteDefenseAbility(Owner, Owner.enemy, Damage);
    }
}
