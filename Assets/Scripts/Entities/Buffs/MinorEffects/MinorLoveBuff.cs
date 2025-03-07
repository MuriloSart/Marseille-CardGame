internal class MinorLoveBuff : EffectBase
{
    private readonly int _buffValue;
    private readonly Heal heal = new Heal();
    private readonly Entity enemy;

    public MinorLoveBuff(Entity entity, Entity enemy, int buffValue, TypeOfEffect type) : base(entity, type)
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
        enemy.selectedCards.cards[0].Damage -= _buffValue;
    }

    public override void RemoveAttackEffect()
    {
        return;
    }

    public override void RemoveDefenseEffect()
    {
        enemy.selectedCards.cards[0].Damage += _buffValue;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}