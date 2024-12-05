internal class UltimateLoveBuff : EffectBase
{
    private int _buffValue;
    private Heal heal = new Heal();

    public UltimateLoveBuff(Entity entity, int buffValue, TypeOfEffect type) : base(entity,type)
    {
        this.entity = entity;
        this._buffValue = buffValue;
    }

    public override void ApplyAttackEffect()
    {
        heal.Restore(entity, _buffValue);
    }

    public override void ApplyDefenseEffect()
    {
        entity.Health.maxLife += _buffValue;
    }

    public override void RemoveAttackEffect()
    {
        return;
    }

    public override void RemoveDefenseEffect()
    {
        entity.Health.maxLife -= _buffValue;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}