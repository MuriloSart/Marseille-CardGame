public class MinorDeathBuff : EffectBase
{
    private readonly int _damage;
    private readonly int _damageResist;

    public MinorDeathBuff(Entity entity, TypeOfEffect type, int damage, int damageResist) : base(entity, type)
    {
        this._damage = damage;
        this._damageResist = damageResist;
    }

    public override void ApplyAttackEffect()
    {
        Dealer.Instance.Deal.ToEntity(entity, entity.drawPile);
        entity.AcquireCards();
        entity.selectedCards.cards[0].damageType.Deal(entity, _damage);
    }

    public override void ApplyDefenseEffect()
    {
        entity.DamageResist += _damageResist;
    }

    public override void RemoveAttackEffect()
    {
        return;
    }

    public override void RemoveDefenseEffect()
    {
        entity.DamageResist -= _damageResist;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}
