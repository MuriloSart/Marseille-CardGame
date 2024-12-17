public class HighHopeAbility : EffectBase
{
    private readonly int amountDamage;
    private readonly int amountEffectResist;

    public HighHopeAbility(Entity entity, int amountDamage, int amountEffectResist, TypeOfEffect type) : base(entity, type)
    {
        this.amountDamage = amountDamage;
        this.amountEffectResist = amountEffectResist;
        _turns = 1;
    }

    public override void ApplyAttackEffect()
    {
        EffectOverTime = BuffAttack;
        entity.EffectResist += amountEffectResist;
    }

    public override void ApplyDefenseEffect()
    {
        EffectOverTime = BuffAttack;
        entity.EffectResist += amountEffectResist;
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
        entity.selectedCards.cards[0].Damage += amountDamage;
    }

    private void DebuffAttack()
    {
        entity.selectedCards.cards[0].Damage -= amountDamage;
        entity.EffectResist -= amountEffectResist;
    }
}
