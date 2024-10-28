using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class DeathAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/DeathImg";

    private EffectBase _effect;

    public EffectBase ExecuteAttackAbility(Entity entity, Entity enemy, int cardValue)
    {
        switch (cardValue)
        {
            case 1:
                _effect = new MinorDeathBuff(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 2:
                _effect = new MinorDeathBuff(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 3:
                _effect = new MinorDeathBuff(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 4:
                _effect = new MediumDeathBuff(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 5:
                _effect = new MediumDeathBuff(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 6:
                _effect = new MediumDeathBuff(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 7:
                _effect = new HighDeathAbility(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 8:
                _effect = new HighDeathAbility(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 9:
                _effect = new HighDeathAbility(entity, EffectBase.TypeOfEffect.Attack);
                break;
            case 10:
                _effect = new UltimateDeathEffect(entity, EffectBase.TypeOfEffect.Attack);
                break;

        }
        entity.TakeEffect(_effect);

        return _effect;
    }

    public EffectBase ExecuteDefenseAbility(Entity entity, Entity enemy, int cardValue)
    {
            switch (cardValue)
            {
                case 1:
                    _effect = new MinorDeathBuff(entity, EffectBase.TypeOfEffect.Defense);
                    break;
                case 2:
                    _effect = new MinorDeathBuff(entity, EffectBase.TypeOfEffect.Defense);
                    break;
                case 3:
                    _effect = new MinorDeathBuff(entity, EffectBase.TypeOfEffect.Defense);
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
                case 10:
                    _effect = new UltimateHopeEffect(entity, powerUpMinor, heal, EffectBase.TypeOfEffect.Defense);
                    break;
            }
            entity.TakeEffect(_effect);

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
