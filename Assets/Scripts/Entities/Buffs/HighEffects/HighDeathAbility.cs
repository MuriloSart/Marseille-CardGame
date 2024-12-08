public class HighDeathAbility : EffectBase
{
    private Damage damageDealer = new Damage();
    private readonly int _damage;
    private readonly int _damageResist;

    public HighDeathAbility(Entity entity, TypeOfEffect type, int damage, int damageResist) : base(entity, type)
    {
        _damage = damage;
        _damageResist = damageResist;
    }

    public override void ApplyAttackEffect() 
    {
        Dealer.Instance.Deal.ToEntity(entity, entity.drawPile);
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
