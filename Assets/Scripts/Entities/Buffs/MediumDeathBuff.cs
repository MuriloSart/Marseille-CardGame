public class MediumDeathBuff : EffectBase
{
    private int _damage;
    private int _damageResist;
    private Damage _damageDealer = new Damage();
    public MediumDeathBuff(Entity entity, TypeOfEffect type, int damage, int damageResist) : base(entity, type)
    {
        _damage = damage;
        _damageResist = damageResist;
    }

    public override void ApplyAttackEffect()
    {
        DealCard.Instance.ToEntity(entity, entity.Deck);
        _damageDealer.Deal(entity, _damage);
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
