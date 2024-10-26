using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
internal class LoveAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/LoveImg";

    private EffectBase effect;
    private int minorHeal = 3;
    private int mediumHeal = 5;
    private int ultimateHeal = 10;

    public void ExecuteAttackAbility(Entity entity, Entity enemy, int amount)
    {
        switch (amount)
        {
            case 1:
                effect = new MinorLoveBuff(entity, minorHeal, EffectBase.TypeOfEffect.Attack);
                break;
            case 2:
                effect = new MinorLoveBuff(entity, minorHeal, EffectBase.TypeOfEffect.Attack);
                break;
            case 3:
                effect = new MinorLoveBuff(entity, minorHeal, EffectBase.TypeOfEffect.Attack);
                break;
            case 4:
                effect = new MediumLoveBuff(entity, mediumHeal, EffectBase.TypeOfEffect.Attack);
                break;
            case 5:
                effect = new MediumLoveBuff(entity, mediumHeal, EffectBase.TypeOfEffect.Attack);
                break;
            case 6:
                effect = new MediumLoveBuff(entity, mediumHeal, EffectBase.TypeOfEffect.Attack);
                break;
            case 7:
                effect = new HighLoveBuff(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 8:
                effect = new HighLoveBuff(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 9:
                effect = new HighLoveBuff(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 10:
                effect = new UltimateLoveBuff(entity, ultimateHeal, EffectBase.TypeOfEffect.Attack);
                break;
        }
        entity.TakeEffect(effect);
    }

    public void ExecuteDefenseAbility(Entity entity, Entity enemy, int amount)
    {
        switch (amount)
        {
            case 1:
                effect = new MinorLoveBuff(entity, minorHeal, EffectBase.TypeOfEffect.Defense);
                break;
            case 2:
                effect = new MinorLoveBuff(entity, minorHeal, EffectBase.TypeOfEffect.Defense);
                break;
            case 3:
                effect = new MinorLoveBuff(entity, minorHeal, EffectBase.TypeOfEffect.Defense);
                break;
            case 4:
                effect = new MediumLoveBuff(entity, mediumHeal, EffectBase.TypeOfEffect.Defense);
                break;
            case 5:
                effect = new MediumLoveBuff(entity, mediumHeal, EffectBase.TypeOfEffect.Defense);
                break;
            case 6:
                effect = new MediumLoveBuff(entity, mediumHeal, EffectBase.TypeOfEffect.Defense);
                break;
            case 7:
                effect = new HighLoveBuff(entity, EffectBase.TypeOfEffect.Defense);
                break;
            case 8:
                effect = new HighLoveBuff(entity, EffectBase.TypeOfEffect.Defense);
                break;
            case 9:
                effect = new HighLoveBuff(entity, EffectBase.TypeOfEffect.Defense);
                break;
            case 10:
                effect = new UltimateLoveBuff(entity, ultimateHeal, EffectBase.TypeOfEffect.Defense);
                break;
        }
        entity.TakeEffect(effect);
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite do Amor não encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}