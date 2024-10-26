using System;

public class MinorHopeBuff : EffectBase
{
    private readonly Entity entity;
    private readonly int amountDamage;

    public MinorHopeBuff(Entity entity, int amountDamage, TypeOfEffect type) : base(type)
    {
        this.entity = entity;
        this.amountDamage = amountDamage;
        _turns = 1;
    }

    public override void ApplyAttackEffect()
    {
        EffectOverTime = BuffAttack;
    }

    public override void ApplyDefenseEffect()
    {
        EffectOverTime = BuffAttack;
    }

    public override void RemoveAttackEffect()
    {
        RemoveBuff();
    }

    public override void RemoveDefenseEffect()
    {
        RemoveBuff();
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }

    public void BuffAttack()
    {
        entity.selectedCards[0].Damage += amountDamage;
    }

    public void RemoveBuff()
    {
        entity.selectedCards[0].Damage -= amountDamage;
    }
    
}
