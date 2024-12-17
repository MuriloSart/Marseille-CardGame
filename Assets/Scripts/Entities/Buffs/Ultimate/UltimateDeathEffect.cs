public class UltimateDeathEffect : EffectBase
{ 
    public UltimateDeathEffect(Entity entity, TypeOfEffect type) : base(entity, type)
    {
        _turns = -1;
    }

    public override void ApplyAttackEffect()
    {
        EffectOverTime = CanDie;
    }

    public override void ApplyDefenseEffect()
    {
        entity.DamageResist += 10;
    }

    public override void RemoveAttackEffect()
    {
        entity.death.canDie = true;
    }

    public override void RemoveDefenseEffect()
    {
        entity.DamageResist -= 10;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }

    private void CanDie()
    {
        entity.death.canDie = false;
    }
}

