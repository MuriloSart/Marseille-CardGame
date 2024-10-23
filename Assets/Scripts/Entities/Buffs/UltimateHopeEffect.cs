public class UltimateHopeEffect : EffectBase
{
    private readonly Entity player;
    private readonly int amountDamage;
    private readonly int amountHeal;

    public UltimateHopeEffect(Entity player, int amountDamage, int amountHeal, TypeOfEffect type) : base(type)
    {
        this.player = player;
        this.amountDamage = amountDamage;
        this.amountHeal = amountHeal;
    }

    public override void ApplyAttackEffect()
    {
        EffectOverTime = MasterEffect;
    }

    public override void ApplyDefenseEffect()
    {
        EffectOverTime = MasterEffect;
    }

    public override void RemoveAttackEffect()
    {
        player.selectedCards[0].Damage -= amountDamage;
    }
    public override void RemoveDefenseEffect()
    {
        player.selectedCards[0].Damage -= amountDamage;
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }

    public void MasterEffect()
    {
        player.selectedCards[0].Damage += amountDamage;
        player.health.Heal(amountHeal);
    }
}
