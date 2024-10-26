using System;

public abstract class EffectBase
{
    protected int _turns = 0;
    public Action EffectOverTime;
    public Action ApplyEffect;
    public Action RemoveEffect;

    public int Turns
    {
        get { return _turns; }
    }

    public void DiscountingTurn()
    {
        _turns--;
    }

    public enum TypeOfEffect
    {
        Defense,
        Attack
    }

    public EffectBase(TypeOfEffect type)
    {
        if (type == TypeOfEffect.Attack)
        {
            ApplyEffect = ApplyAttackEffect;
            RemoveEffect = RemoveAttackEffect;
        }
        else
        {
            ApplyEffect = ApplyDefenseEffect;
            RemoveEffect = RemoveDefenseEffect;
        }
    }

    public abstract void ApplyAttackEffect();

    public abstract void ApplyDefenseEffect();

    public abstract void RemoveAttackEffect();

    public abstract void RemoveDefenseEffect();

    public abstract void Render();

}
