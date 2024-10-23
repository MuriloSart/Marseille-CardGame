using UnityEngine;

public class HopeAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/HopeImg";
    private EffectBase effect;
    public int powerUpMinor = 3;
    public int powerUpMedium = 5;
    public int powerUpHigher = 8;
    public int powerUpResist1 = 2;
    public int powerUpResist2 = 3;
    public int powerUpResist3 = 4;
    public int powerUpArmor = 2;
    public int heal = 4;


    public void ExecuteAttackAbility(Entity entity, Entity enemy, int cardValue)
    {
        switch (cardValue)
        {
            case 1:
                effect = new MinorHopeBuff(entity, powerUpMinor, EffectBase.TypeOfEffect.Attack);
                break;
            case 2:
                effect = new MinorHopeBuff(entity, powerUpMinor, EffectBase.TypeOfEffect.Attack);
                break;
            case 3:
                effect = new MinorHopeBuff(entity, powerUpMinor, EffectBase.TypeOfEffect.Attack);
                break;
            case 4:
                effect = new MediumHopeBuff(entity, powerUpMedium, powerUpArmor, EffectBase.TypeOfEffect.Attack);
                break;
            case 5:
                effect = new MediumHopeBuff(entity, powerUpMedium, powerUpArmor, EffectBase.TypeOfEffect.Attack);
                break;
            case 6:
                effect = new MediumHopeBuff(entity, powerUpMedium, powerUpArmor, EffectBase.TypeOfEffect.Attack);
                break;
            case 7:
                effect = new HighHopeAbility(entity, powerUpHigher, powerUpResist1, EffectBase.TypeOfEffect.Attack);
                break;
            case 8:
                effect = new HighHopeAbility(entity, powerUpHigher, powerUpResist2, EffectBase.TypeOfEffect.Attack);
                break;
            case 9:
                effect = new HighHopeAbility(entity, powerUpHigher, powerUpResist3, EffectBase.TypeOfEffect.Attack);
                break;
            case 10:
                effect = new UltimateHopeEffect(entity, powerUpMinor, heal, EffectBase.TypeOfEffect.Attack);
                break;

        }
        entity.TakeEffect(effect);
    }
    public void ExecuteDefenseAbility(Entity entity, Entity enemy, int cardValue)
    {
        switch (cardValue)
        {
            case 1:
                effect = new MinorHopeBuff(entity, powerUpMinor, EffectBase.TypeOfEffect.Defense);
                break;
            case 2:
                effect = new MinorHopeBuff(entity, powerUpMinor, EffectBase.TypeOfEffect.Defense);
                break;
            case 3:
                effect = new MinorHopeBuff(entity, powerUpMinor, EffectBase.TypeOfEffect.Defense);
                break;
            case 4:
                effect = new MediumHopeBuff(entity, powerUpMedium, powerUpArmor, EffectBase.TypeOfEffect.Defense);
                break;
            case 5:
                effect = new MediumHopeBuff(entity, powerUpMedium, powerUpArmor, EffectBase.TypeOfEffect.Defense);
                break;
            case 6:
                effect = new MediumHopeBuff(entity, powerUpMedium, powerUpArmor, EffectBase.TypeOfEffect.Defense);
                break;
            case 7:
                effect = new HighHopeAbility(entity, powerUpHigher, powerUpResist1, EffectBase.TypeOfEffect.Defense);
                break;
            case 8:
                effect = new HighHopeAbility(entity, powerUpHigher, powerUpResist2, EffectBase.TypeOfEffect.Defense);
                break;
            case 9:
                effect = new HighHopeAbility(entity, powerUpHigher, powerUpResist3, EffectBase.TypeOfEffect.Defense);
                break;
            case 10:
                effect = new UltimateHopeEffect(entity, powerUpMinor, heal, EffectBase.TypeOfEffect.Defense);
                break;
        }
        entity.TakeEffect(effect);
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite da Esperança não encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}
