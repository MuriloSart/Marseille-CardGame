internal class MediumLoveBuff : EffectBase
{
    private int _buffValue;
    private int _damageValue;
    private Heal heal = new Heal();

    public MediumLoveBuff(Entity entity, int buffValue, TypeOfEffect type) : base(entity, type)
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
        _damageValue = entity.selectedCards[0].Damage / 2;
        entity.selectedCards[0].Damage -= _damageValue;
    }

    public override void RemoveAttackEffect()
    {
        return;
    }

    public override void RemoveDefenseEffect()
    {
        entity.selectedCards[0].Damage += _damageValue;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}