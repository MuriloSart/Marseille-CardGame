public class EffectManager : Singleton<EffectManager>
{
    private Entity entity;
    private int debuffDamage;
    private int enemyData;
    private bool guiltActived = false;

    public bool GuiltActived { get => guiltActived; }

    public void ActiveGuiltAbility(Entity entity, int debuffDamage)
    {
        this.entity = entity;
        this.debuffDamage = debuffDamage;
        this.guiltActived = true;
    }

    public int RestoringEnemy()
    {
        return this.enemyData;
    }

    public void GuiltDebuff()
    {
        if (!guiltActived) return;
        if(debuffDamage <= 0) return;
        RemoveEffect(entity.enemy, entity.enemy.selectedCards.cards[1].Effect);

        enemyData = entity.enemy.selectedCards.cards[1].Damage;
        entity.enemy.selectedCards.cards[1].Damage -= debuffDamage;
        entity.enemy.selectedCards.cards[1].Renew();
        TakeEffect(entity.enemy, entity.enemy.selectedCards.cards[1].Effect);
        guiltActived = false;
    }

    public void TakeEffect(Entity entity, EffectBase effect)
    {
        effect.ApplyEffect();
        entity.effects.Add(effect);
    }

    public void TakeEffectOverTurn(EffectBase effect)
    {
        if (effect == null) return;

        if (effect.EffectOverTime == null) return;

        if (effect.Turns > 1)
        {
            effect.DiscountingTurn();
            effect.EffectOverTime();
        }
        else if (effect.Turns == 1)
        {
            effect.EffectOverTime();
        }
        else
            effect.EffectOverTime();

    }

    public void RemoveAllEffects(Entity entity)
    {
        for (int i = entity.effects.Count - 1; i >= 0; i--)
        {
            if (entity.effects[i].Turns == 1 || entity.effects[i].EffectOverTime is null)
                RemoveEffect(entity, entity.effects[i]);
        }
    }

    public void RemoveEffect(Entity entity, EffectBase effect)
    {
        if(effect.RemoveEffect == null) return;

        effect.RemoveEffect();
        entity.effects.Remove(effect);
    }
}
