public class UltimateGuiltBuff : EffectBase
{
    private int damageResist;
    public UltimateGuiltBuff(Entity entity, int damageResist, TypeOfEffect type) : base(entity, type)
    {
        this.damageResist = damageResist;
    }

    public override void ApplyAttackEffect()
    {
        EffectManager.Instance.ActiveGuiltAbility(entity, 0);
    }

    public override void ApplyDefenseEffect()
    {
        entity.DamageResist += damageResist;
    }

    public override void RemoveAttackEffect()
    {
        UnityEngine.Debug.Log("UltimateGuilt removido");
    }

    public override void RemoveDefenseEffect()
    {
        entity.DamageResist -= damageResist;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}
