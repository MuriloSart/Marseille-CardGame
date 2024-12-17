public class HighDeathAbility : EffectBase
{
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
