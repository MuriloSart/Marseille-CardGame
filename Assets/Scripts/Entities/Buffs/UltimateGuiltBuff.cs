class UltimateGuiltBuff : EffectBase
{
    private int damageResist;
    public UltimateGuiltBuff(Entity entity, int damageResist, TypeOfEffect type) : base(entity, type)
    {
        this.damageResist = damageResist;
    }

    public override void ApplyAttackEffect()
    {
        entity.RemoveEffect(entity.selectedCards[1].Effect);
    }

    public override void ApplyDefenseEffect()
    {
        entity.damageResist += damageResist;
    }

    public override void RemoveAttackEffect()
    {
        return;
    }

    public override void RemoveDefenseEffect()
    {
        entity.damageResist -= damageResist;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}
