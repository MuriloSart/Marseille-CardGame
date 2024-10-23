public class MediumHopeBuff : EffectBase
{
    private readonly Entity player;
    private readonly int amountDamage;
    private readonly int amountResist;

    public MediumHopeBuff(Entity player, int amountDamage, int amountResist, TypeOfEffect type) : base(type)
    {
        this.player = player;
        this.amountDamage = amountDamage;
        this.amountResist = amountResist;
    }

    public override void ApplyAttackEffect()
    {
        EffectOverTime = BuffAttack;
    }

    public override void ApplyDefenseEffect()
    {
        EffectOverTime = BuffProtect;
    }

    public override void RemoveAttackEffect()
    {
        DebuffAttack();
    }

    public override void RemoveDefenseEffect()
    {
        DebuffAttack();
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }

    public void BuffAttack()
    {
        player.selectedCards[0].Damage += amountDamage;
    }

    public void BuffProtect()
    {
        player.damageResist += amountResist;
    }

    public void DebuffAttack()
    {
        player.selectedCards[0].Damage -= amountDamage;
    }
}
