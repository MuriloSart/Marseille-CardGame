public class HighDeathAbility : EffectBase
{
    private Damage damageDealer = new Damage();
    private int _damage;
    private int _damageResist;
    public HighDeathAbility(Entity entity, TypeOfEffect type, int damage, int damageResist) : base(entity, type)
    {
        _damage = damage;
        _damageResist = damageResist;
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
