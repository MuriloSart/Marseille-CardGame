public class MediumHopeBuff : EffectBase
{
    private readonly int amountDamage;
    private readonly int amountResist;

    public MediumHopeBuff(Entity entity, int amountDamage, int amountResist, TypeOfEffect type) : base(entity, type)
    {
        this.amountDamage = amountDamage;
        this.amountResist = amountResist;
        _turns = 1;
    }

    public override void ApplyAttackEffect()
    {
        EffectOverTime = BuffAttack;
    }

    public override void ApplyDefenseEffect()
    {
        EffectOverTime = BuffProtect;
    }

    public override void RemoveAttackEffect()
    {
        DebuffAttack();
    }

    public override void RemoveDefenseEffect()
    {
        DebuffAttack();
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }

    public void BuffAttack()
    {
        entity.selectedCards.cards[0].Damage += amountDamage;
    }

    public void BuffProtect()
    {
        entity.DamageResist += amountResist;
    }

    public void DebuffAttack()
    {
        entity.selectedCards.cards[0].Damage -= amountDamage;
        if (EffectOverTime == BuffProtect)
            entity.DamageResist -= amountResist;
    }
}
