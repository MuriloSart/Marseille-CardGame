internal class MediumLoveBuff : EffectBase
{
    private int _buffValue;
    private int _damageValue;
    private Entity enemy;
    private Heal heal = new Heal();

    public MediumLoveBuff(Entity entity, Entity enemy, int buffValue, TypeOfEffect type) : base(entity, type)
    {
        this.entity = entity;
        this._buffValue = buffValue;
        this.enemy = enemy;
    }

    public override void ApplyAttackEffect()
    {
        heal.Restore(entity, _buffValue);
    }

    public override void ApplyDefenseEffect()
    {
        _damageValue = enemy.selectedCards.cards[0].Damage / 2;
        enemy.selectedCards.cards[0].Damage -= _damageValue;
    }

    public override void RemoveAttackEffect()
    {
        return;
    }

    public override void RemoveDefenseEffect()
    {
        enemy.selectedCards.cards[0].Damage += _damageValue;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}