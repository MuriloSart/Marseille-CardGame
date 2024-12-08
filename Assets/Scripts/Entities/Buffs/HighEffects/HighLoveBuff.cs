internal class HighLoveBuff : EffectBase
{
    private Heal heal = new Heal();
    public HighLoveBuff(Entity entity, TypeOfEffect type) : base(entity, type)
    {
        this.entity = entity;
    }

    public override void ApplyAttackEffect()
    {
        heal.Restore(entity, entity.health.maxLife / 2);
    }

    public override void ApplyDefenseEffect()
    {
        heal.Restore(entity, entity.health.maxLife / 2);
    }

    public override void RemoveAttackEffect()
    {
        return;
    }

    public override void RemoveDefenseEffect()
    {
        return;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}