using UnityEngine;

public class GuiltAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/GuiltImg";

    private EffectBase _effect;
    private int _minorDebuffDamage = 1;
    private int _minorDamageResist = 2;
    private int _mediumDebuffDamage = 2;
    private int _mediumDamageResist = 4;
    private int _highDebuffDamage = 4;
    private int _highDamageResist = 6;
    private int _ultimateDamageResist = 10;

    public EffectBase ExecuteAttackAbility(Entity entity, Entity enemy, int cardValue)
    {
        Debug.Log("Habilidade Ataque da Culpa usada");

        switch (cardValue)
        {
            case 1:
                _effect = new MinorGuiltBuff(entity, _minorDebuffDamage, _minorDamageResist, EffectBase.TypeOfEffect.Attack);
                break;
            case 2:
                _effect = new MinorGuiltBuff(entity, _minorDebuffDamage, _minorDamageResist, EffectBase.TypeOfEffect.Attack);
                break;
            case 3:
                _effect = new MinorGuiltBuff(entity, _minorDebuffDamage, _minorDamageResist, EffectBase.TypeOfEffect.Attack);
                break;
            case 4:
                _effect = new MediumGuiltBuff(entity, _mediumDebuffDamage, _mediumDamageResist, EffectBase.TypeOfEffect.Attack);
                break;
            case 5:
                _effect = new MediumGuiltBuff(entity, _mediumDebuffDamage, _mediumDamageResist, EffectBase.TypeOfEffect.Attack);
                break;
            case 6:
                _effect = new MediumGuiltBuff(entity, _mediumDebuffDamage, _mediumDamageResist, EffectBase.TypeOfEffect.Attack);
                break;
            case 7:
                _effect = new HighGuiltBuff(entity, _highDebuffDamage, _highDamageResist,  EffectBase.TypeOfEffect.Attack);
                break;
            case 8:
                _effect = new HighGuiltBuff(entity, _highDebuffDamage, _highDamageResist, EffectBase.TypeOfEffect.Attack);
                break;
            case 9:
                _effect = new HighGuiltBuff(entity, _highDebuffDamage, _highDamageResist, EffectBase.TypeOfEffect.Attack);
                break;
            case 10:
                _effect = new UltimateGuiltBuff(entity, _ultimateDamageResist, EffectBase.TypeOfEffect.Attack);
                break;
        }
        EffectManager.Instance.TakeEffect(entity, _effect);

        return _effect;
    }

    public EffectBase ExecuteDefenseAbility(Entity entity, Entity enemy, int cardValue)
    {
        Debug.Log("Habilidade Ataque da Culpa usada");

        switch (cardValue)
        {
            case 1:
                _effect = new MinorGuiltBuff(entity, _minorDebuffDamage, _minorDamageResist, EffectBase.TypeOfEffect.Defense);
                break;
            case 2:
                _effect = new MinorGuiltBuff(entity, _minorDebuffDamage, _minorDamageResist, EffectBase.TypeOfEffect.Defense);
                break;
            case 3:
                _effect = new MinorGuiltBuff(entity, _minorDebuffDamage, _minorDamageResist, EffectBase.TypeOfEffect.Defense);
                break;
            case 4:
                _effect = new MediumGuiltBuff(entity, _mediumDebuffDamage, _mediumDamageResist, EffectBase.TypeOfEffect.Defense);
                break;
            case 5:
                _effect = new MediumGuiltBuff(entity, _mediumDebuffDamage, _mediumDamageResist, EffectBase.TypeOfEffect.Defense);
                break;
            case 6:
                _effect = new MediumGuiltBuff(entity, _mediumDebuffDamage, _mediumDamageResist, EffectBase.TypeOfEffect.Defense);
                break;
            case 7:
                _effect = new HighGuiltBuff(entity, _highDebuffDamage, _highDamageResist, EffectBase.TypeOfEffect.Defense);
                break;
            case 8:
                _effect = new HighGuiltBuff(entity, _highDebuffDamage, _highDamageResist, EffectBase.TypeOfEffect.Defense);
                break;
            case 9:
                _effect = new HighGuiltBuff(entity, _highDebuffDamage, _highDamageResist, EffectBase.TypeOfEffect.Defense);
                break;
            case 10:
                _effect = new UltimateGuiltBuff(entity, _ultimateDamageResist, EffectBase.TypeOfEffect.Defense);
                break;
        }
        EffectManager.Instance.TakeEffect(entity, _effect);

        return _effect;
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite da Culpa não encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}
