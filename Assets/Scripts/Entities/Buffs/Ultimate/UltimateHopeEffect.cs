public class UltimateHopeEffect : EffectBase
{
    private readonly int _damageValue;
    private readonly int _healValue;
    private readonly Heal heal = new Heal();

    public UltimateHopeEffect(Entity entity, int amountDamage, int amountHeal, TypeOfEffect type) : base(entity, type)
    {
        this._damageValue = amountDamage;
        this._healValue = amountHeal;
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
        entity.selectedCards.cards[0].Damage -= _damageValue;
    }
    public override void RemoveDefenseEffect()
    {
        entity.selectedCards.cards[0].Damage -= _damageValue;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }

    public void MasterEffect()
    {
        entity.selectedCards.cards[0].Damage += _damageValue;
        heal.Restore(entity, _healValue);
    }
}
