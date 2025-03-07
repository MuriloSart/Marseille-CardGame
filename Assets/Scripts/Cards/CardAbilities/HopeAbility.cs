using UnityEngine;

public class HopeAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/HopeImg";
    private EffectBase _effect;
    public int powerUpMinor = 3;
    public int powerUpMedium = 5;
    public int powerUpHigher = 8;
    public int powerUpResist1 = 2;
    public int powerUpResist2 = 3;
    public int powerUpResist3 = 4;
    public int powerUpArmor = 2;
    public int heal = 4;


    public EffectBase ExecuteAttackAbility(Entity entity, Entity enemy, int cardValue)
    {
        switch (cardValue)
        {
            case 1:
                _effect = new MinorHopeBuff(entity, powerUpMinor, EffectBase.TypeOfEffect.Attack);
                break;
            case 2:
                _effect = new MinorHopeBuff(entity, powerUpMinor, EffectBase.TypeOfEffect.Attack);
                break;
            case 3:
                _effect = new MinorHopeBuff(entity, powerUpMinor, EffectBase.TypeOfEffect.Attack);
                break;
            case 4:
                _effect = new MediumHopeBuff(entity, powerUpMedium, powerUpArmor, EffectBase.TypeOfEffect.Attack);
                break;
            case 5:
                _effect = new MediumHopeBuff(entity, powerUpMedium, powerUpArmor, EffectBase.TypeOfEffect.Attack);
                break;
            case 6:
                _effect = new MediumHopeBuff(entity, powerUpMedium, powerUpArmor, EffectBase.TypeOfEffect.Attack);
                break;
            case 7:
                _effect = new HighHopeAbility(entity, powerUpHigher, powerUpResist1, EffectBase.TypeOfEffect.Attack);
                break;
            case 8:
                _effect = new HighHopeAbility(entity, powerUpHigher, powerUpResist2, EffectBase.TypeOfEffect.Attack);
                break;
            case 9:
                _effect = new HighHopeAbility(entity, powerUpHigher, powerUpResist3, EffectBase.TypeOfEffect.Attack);
                break;
            default:
                _effect = new UltimateHopeEffect(entity, powerUpMinor, heal, EffectBase.TypeOfEffect.Attack);
                break;

        }
        EffectManager.Instance.TakeEffect(entity, _effect);

        return _effect;
    }
    public EffectBase ExecuteDefenseAbility(Entity entity, Entity enemy, int cardValue)
    {
        switch (cardValue)
        {
            case 1:
                _effect = new MinorHopeBuff(entity, powerUpMinor, EffectBase.TypeOfEffect.Defense);
                break;
            case 2:
                _effect = new MinorHopeBuff(entity, powerUpMinor, EffectBase.TypeOfEffect.Defense);
                break;
            case 3:
                _effect = new MinorHopeBuff(entity, powerUpMinor, EffectBase.TypeOfEffect.Defense);
                break;
            case 4:
                _effect = new MediumHopeBuff(entity, powerUpMedium, powerUpArmor, EffectBase.TypeOfEffect.Defense);
                break;
            case 5:
                _effect = new MediumHopeBuff(entity, powerUpMedium, powerUpArmor, EffectBase.TypeOfEffect.Defense);
                break;
            case 6:
                _effect = new MediumHopeBuff(entity, powerUpMedium, powerUpArmor, EffectBase.TypeOfEffect.Defense);
                break;
            case 7:
                _effect = new HighHopeAbility(entity, powerUpHigher, powerUpResist1, EffectBase.TypeOfEffect.Defense);
                break;
            case 8:
                _effect = new HighHopeAbility(entity, powerUpHigher, powerUpResist2, EffectBase.TypeOfEffect.Defense);
                break;
            case 9:
                _effect = new HighHopeAbility(entity, powerUpHigher, powerUpResist3, EffectBase.TypeOfEffect.Defense);
                break;
            default:
                _effect = new UltimateHopeEffect(entity, powerUpMinor, heal, EffectBase.TypeOfEffect.Defense);
                break;
        }
        EffectManager.Instance.TakeEffect(entity, _effect);

        return _effect;
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite da Esperança não encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}
