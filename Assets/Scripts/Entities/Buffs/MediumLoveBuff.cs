internal class MediumLoveBuff : EffectBase
{
    private int buffValue;
    private int damageValue;

    public MediumLoveBuff(Entity entity, int buffValue, TypeOfEffect type) : base(entity, type)
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
        damageValue = entity.selectedCards[0].Damage / 2;
        entity.selectedCards[0].Damage -= damageValue;
    }

    public override void RemoveAttackEffect()
    {
        return;
    }

    public override void RemoveDefenseEffect()
    {
        entity.selectedCards[0].Damage += damageValue;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}