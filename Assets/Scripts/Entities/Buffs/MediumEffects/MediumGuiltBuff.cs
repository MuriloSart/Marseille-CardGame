public class MediumGuiltBuff : EffectBase
{
    private int damageResist;
    private int debuffDamage;
    public MediumGuiltBuff(Entity entity, int debuffDamage, int damageResist, TypeOfEffect type) : base(entity, type)
    {
    }

    public override void ApplyAttackEffect()
    {
        EffectManager.Instance.RemoveEffect(entity, entity.selectedCards.cards[1].Effect);
        entity.selectedCards.cards[1].Damage -= debuffDamage;
        entity.selectedCards.cards[1].Ability();
    }

    public override void ApplyDefenseEffect()
    {
        entity.damageResist += damageResist;
    }

    public override void RemoveAttackEffect()
    {
        entity.selectedCards.cards[1].Damage += debuffDamage;
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
