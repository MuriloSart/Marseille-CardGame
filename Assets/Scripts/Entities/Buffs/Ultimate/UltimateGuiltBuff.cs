class UltimateGuiltBuff : EffectBase
{
    private int damageResist;
    public UltimateGuiltBuff(Entity entity, int damageResist, TypeOfEffect type) : base(entity, type)
    {
        this.damageResist = damageResist;
    }

    public override void ApplyAttackEffect()
    {
        EffectManager.Instance.RemoveEffect(entity, entity.selectedCards.cards[1].Effect);
    }

    public override void ApplyDefenseEffect()
    {
        entity.DamageResist += damageResist;
    }

    public override void RemoveAttackEffect()
    {
        return;
    }

    public override void RemoveDefenseEffect()
    {
        entity.DamageResist -= damageResist;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}
