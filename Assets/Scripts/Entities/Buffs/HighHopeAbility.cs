public class HighHopeAbility : EffectBase
{
    private readonly Entity entity;
    private readonly int amountDamage;
    private readonly int amountEffectResist;

    public HighHopeAbility(Entity entity, int amountDamage, int amountEffectResist, TypeOfEffect type) : base(type)
    {
        this.entity = entity;
        this.amountDamage = amountDamage;
        this.amountEffectResist = amountEffectResist;
        _turns = 1;
    }

    public override void ApplyAttackEffect()
    {
        EffectOverTime = BuffAttack;
        entity.effectResist += amountEffectResist;
    }

    public override void ApplyDefenseEffect()
    {
        EffectOverTime = BuffAttack;
        entity.effectResist += amountEffectResist;
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

    private void BuffAttack()
    {
        entity.selectedCards[0].Damage += amountDamage;
    }

    private void DebuffAttack()
    {
        entity.selectedCards[0].Damage -= amountDamage;
        entity.effectResist -= amountEffectResist;
    }
}
