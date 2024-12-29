using UnityEngine;

public class DeathAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/DeathImg";

    private EffectBase _effect;

    public int minorDamage = 1;
    public int mediumDamage = 2;
    public int highDamage = 3;

    public int minorResist = 2;
    public int mediumResist = 4;
    public int highResist = 6;

    public EffectBase ExecuteAttackAbility(Entity entity, Entity enemy, int cardValue)
    {
        if (cardValue < 0) cardValue = 1;
        switch (cardValue)
        {
            case 1:
                _effect = new MinorDeathBuff(entity, EffectBase.TypeOfEffect.Attack, minorDamage, minorResist);
                break;
            case 2:
                _effect = new MinorDeathBuff(entity, EffectBase.TypeOfEffect.Attack, minorDamage, minorResist);
                break;
            case 3:
                _effect = new MinorDeathBuff(entity, EffectBase.TypeOfEffect.Attack, minorDamage, minorResist);
                break;
            case 4:
                _effect = new MediumDeathBuff(entity, EffectBase.TypeOfEffect.Attack, mediumDamage, mediumResist);
                break;
            case 5:
                _effect = new MediumDeathBuff(entity, EffectBase.TypeOfEffect.Attack, mediumDamage, mediumResist);
                break;
            case 6:
                _effect = new MediumDeathBuff(entity, EffectBase.TypeOfEffect.Attack, mediumDamage, mediumResist);
                break;
            case 7:
                _effect = new HighDeathAbility(entity, EffectBase.TypeOfEffect.Attack, highDamage, highResist);
                break;
            case 8:
                _effect = new HighDeathAbility(entity, EffectBase.TypeOfEffect.Attack, highDamage, highResist);
                break;
            case 9:
                _effect = new HighDeathAbility(entity, EffectBase.TypeOfEffect.Attack, highDamage, highResist);
                break;
            case 10:
                _effect = new UltimateDeathEffect(entity, EffectBase.TypeOfEffect.Attack);
                break;

        }
        EffectManager.Instance.TakeEffect(entity, _effect);

        return _effect;
    }

    public EffectBase ExecuteDefenseAbility(Entity entity, Entity enemy, int cardValue)
    {
        if (cardValue < 0) cardValue = 1;
        switch (cardValue)
            {
                case 1:
                    _effect = new MinorDeathBuff(entity, EffectBase.TypeOfEffect.Defense, minorDamage, minorResist);
                    break;
                case 2:
                    _effect = new MinorDeathBuff(entity, EffectBase.TypeOfEffect.Defense, minorDamage, minorResist);
                    break;
                case 3:
                    _effect = new MinorDeathBuff(entity, EffectBase.TypeOfEffect.Defense, minorDamage, minorResist);
                    break;
                case 4:
                    _effect = new MediumDeathBuff(entity, EffectBase.TypeOfEffect.Defense, mediumDamage, mediumResist);
                    break;
                case 5:
                    _effect = new MediumDeathBuff(entity, EffectBase.TypeOfEffect.Defense, mediumDamage, mediumResist);
                    break;
                case 6:
                    _effect = new MediumDeathBuff(entity, EffectBase.TypeOfEffect.Defense, mediumDamage, mediumResist);
                    break;
                case 7:
                    _effect = new HighDeathAbility(entity, EffectBase.TypeOfEffect.Defense, highDamage, highResist);
                    break;
                case 8:
                    _effect = new HighDeathAbility(entity, EffectBase.TypeOfEffect.Defense, highDamage, highResist);
                    break;
                case 9:
                    _effect = new HighDeathAbility(entity, EffectBase.TypeOfEffect.Defense, highDamage, highResist);
                    break;
                case 10:
                    _effect = new UltimateDeathEffect(entity, EffectBase.TypeOfEffect.Defense);
                    break;
            }
            EffectManager.Instance.TakeEffect(entity, _effect);

            return _effect;
        }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite da Morte não encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}
