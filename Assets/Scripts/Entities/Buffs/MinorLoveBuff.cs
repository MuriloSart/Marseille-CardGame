internal class MinorLoveBuff : EffectBase
{
    private readonly int _buffValue;
    private readonly Heal heal = new Heal();

    public MinorLoveBuff(Entity entity, int buffValue, TypeOfEffect type) : base(entity, type)
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
        entity.selectedCards[0].Damage -= _buffValue;
    }

    public override void RemoveAttackEffect()
    {
        return;
    }

    public override void RemoveDefenseEffect()
    {
        entity.selectedCards[0].Damage += _buffValue;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}