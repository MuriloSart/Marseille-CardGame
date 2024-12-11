using UnityEngine;

public class LoveCard : CardBase
{
    public LoveCard()
    {
        Renew();
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

    public override void Renew()
    {
        _ability = new LoveAbility();
    }
}
