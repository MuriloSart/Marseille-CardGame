internal class MinorLoveBuff : EffectBase
{
    private readonly int buffValue;

    public MinorLoveBuff(Entity entity, int buffValue, TypeOfEffect type) : base(entity, type)
    {
        this.entity = entity;
        this.buffValue = buffValue;
    }

    public override void ApplyAttackEffect()
    {
        entity.health.Heal(buffValue);
    }

    public override void ApplyDefenseEffect()
    {
        entity.selectedCards[0].Damage -= buffValue;
    }

    public override void RemoveAttackEffect()
    {
        return;
    }

    public override void RemoveDefenseEffect()
    {
        entity.selectedCards[0].Damage += buffValue;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}