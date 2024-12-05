public class MinorDeathBuff : EffectBase
{
    private readonly int _damage;
    private readonly int _damageResist;
    private readonly Damage damageDealer = new Damage();

    public MinorDeathBuff(Entity entity, TypeOfEffect type, int damage, int damageResist) : base(entity, type)
    {
        this._damage = damage;
        this._damageResist = damageResist;
    }

    public override void ApplyAttackEffect()
    {
        DealCard.Instance.ToEntity(entity, entity.Deck);
        damageDealer.Deal(entity, _damage);
    }

    public override void ApplyDefenseEffect()
    {
        entity.damageResist += _damageResist;
    }

    public override void RemoveAttackEffect()
    {
        return;
    }

    public override void RemoveDefenseEffect()
    {
        entity.damageResist -= _damageResist;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}
