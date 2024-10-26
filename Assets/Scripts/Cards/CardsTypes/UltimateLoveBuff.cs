internal class UltimateLoveBuff : EffectBase
{
    private Entity entity;
    private int buffValue;

    public UltimateLoveBuff(Entity entity, int buffValue, TypeOfEffect type) : base(type)
    {
        this.entity = entity;
        this.buffValue = buffValue;
    }

    public override void ApplyAttackEffect()
    {
        entity.health.Heal(entity.health.startLife);
    }

    public override void ApplyDefenseEffect()
    {
        entity.health.startLife += buffValue;
    }

    public override void RemoveAttackEffect()
    {
        return;
    }

    public override void RemoveDefenseEffect()
    {
        entity.health.startLife -= buffValue;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}