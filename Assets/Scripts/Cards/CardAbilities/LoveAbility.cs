using UnityEngine;
internal class LoveAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/LoveImg";

    private EffectBase _effect;
    private int minorHeal = 3;
    private int mediumHeal = 5;
    private int ultimateHeal = 10;

    public EffectBase ExecuteAttackAbility(Entity entity, Entity enemy, int cardValue)
    {
        if (cardValue < 0) cardValue = 1;
        switch (cardValue)
        {
            case 1:
                _effect = new MinorLoveBuff(entity, enemy, minorHeal, EffectBase.TypeOfEffect.Attack);
                break;
            case 2:
                _effect = new MinorLoveBuff(entity, enemy, minorHeal, EffectBase.TypeOfEffect.Attack);
                break;
            case 3:
                _effect = new MinorLoveBuff(entity, enemy, minorHeal, EffectBase.TypeOfEffect.Attack);
                break;
            case 4:
                _effect = new MediumLoveBuff(entity, enemy, mediumHeal, EffectBase.TypeOfEffect.Attack);
                break;
            case 5:
                _effect = new MediumLoveBuff(entity, enemy, mediumHeal, EffectBase.TypeOfEffect.Attack);
                break;
            case 6:
                _effect = new MediumLoveBuff(entity, enemy, mediumHeal, EffectBase.TypeOfEffect.Attack);
                break;
            case 7:
                _effect = new HighLoveBuff(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 8:
                _effect = new HighLoveBuff(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 9:
                _effect = new HighLoveBuff(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 10:
                _effect = new UltimateLoveBuff(entity, ultimateHeal, EffectBase.TypeOfEffect.Attack);
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
                _effect = new MinorLoveBuff(entity, enemy, minorHeal, EffectBase.TypeOfEffect.Defense);
                break;
            case 2:
                _effect = new MinorLoveBuff(entity, enemy, minorHeal, EffectBase.TypeOfEffect.Defense);
                break;
            case 3:
                _effect = new MinorLoveBuff(entity, enemy, minorHeal, EffectBase.TypeOfEffect.Defense);
                break;
            case 4:
                _effect = new MediumLoveBuff(entity, enemy, mediumHeal, EffectBase.TypeOfEffect.Defense);
                break;
            case 5:
                _effect = new MediumLoveBuff(entity, enemy, mediumHeal, EffectBase.TypeOfEffect.Defense);
                break;
            case 6:
                _effect = new MediumLoveBuff(entity, enemy, mediumHeal, EffectBase.TypeOfEffect.Defense);
                break;
            case 7:
                _effect = new HighLoveBuff(entity, EffectBase.TypeOfEffect.Defense);
                break;
            case 8:
                _effect = new HighLoveBuff(entity, EffectBase.TypeOfEffect.Defense);
                break;
            case 9:
                _effect = new HighLoveBuff(entity, EffectBase.TypeOfEffect.Defense);
                break;
            case 10:
                _effect = new UltimateLoveBuff(entity, ultimateHeal, EffectBase.TypeOfEffect.Defense);
                break;
        }
        EffectManager.Instance.TakeEffect(entity, _effect);

        return _effect;
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite do Amor não encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}