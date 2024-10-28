public class UltimateHopeEffect : EffectBase
{
    private readonly int currentDamage;
    private readonly int currentHeal;

    public UltimateHopeEffect(Entity entity, int amountDamage, int amountHeal, TypeOfEffect type) : base(entity, type)
    {
        this.currentDamage = amountDamage;
        this.currentHeal = amountHeal;
    }

    public override void ApplyAttackEffect()
    {
        EffectOverTime = MasterEffect;
    }

    public override void ApplyDefenseEffect()
    {
        EffectOverTime = MasterEffect;
    }

    public override void RemoveAttackEffect()
    {
        entity.selectedCards[0].Damage -= currentDamage;
    }
    public override void RemoveDefenseEffect()
    {
        entity.selectedCards[0].Damage -= currentDamage;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }

    public void MasterEffect()
    {
        entity.selectedCards[0].Damage += currentDamage;
        entity.health.Heal(currentHeal);
    }
}
