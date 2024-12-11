public class MediumGuiltBuff : EffectBase
{
    private readonly int damageResist;
    private readonly int debuffDamage;
    public MediumGuiltBuff(Entity entity, int debuffDamage, int damageResist, TypeOfEffect type) : base(entity, type)
    {
        this.damageResist = damageResist;
        this.debuffDamage = debuffDamage;
    }

    public override void ApplyAttackEffect()
    {
        EffectManager.Instance.ActiveGuiltAbility(entity, debuffDamage);
    }

    public override void ApplyDefenseEffect()
    {
        entity.damageResist += damageResist;
    }

    public override void RemoveAttackEffect()
    {
        entity.enemy.selectedCards.cards[1].Damage = EffectManager.Instance.RestoringEnemy();
        entity.enemy.selectedCards.cards[1].Renew();
    }

    public override void RemoveDefenseEffect()
    {
        entity.damageResist -= damageResist;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}
