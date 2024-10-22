using UnityEngine;

public class HopeAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/HopeImg";

    public void ExecuteAttackAbility(Entity player, Entity enemy, int amount)
    {
        player.postEffectActived = true;
        player.postEffects.Add(Buff);
        object[] parameters = new object[] { player.selectedCards[0], 3 };

        switch (amount)
        {
            case 1:
                parameters = new object[] { player.selectedCards[0], 3 };
                break;
            case 2:
                parameters = new object[] { player.selectedCards[0], 3 };
                break;
            case 3:
                parameters = new object[] { player.selectedCards[0], 3 };
                break;
            case 4:
                Buff(new object[] { player.selectedCards[0], 5 });
                parameters = new object[] { player.selectedCards[0], 5 };
                break;
            case 5:
                Buff(new object[] { player.selectedCards[0], 5 });
                parameters = new object[] { player.selectedCards[0], 5 };
                break;
            case 6:
                Buff(new object[] { player.selectedCards[0], 5 });
                parameters = new object[] { player.selectedCards[0], 5 };
                break;
            case 7:
                parameters = new object[] { player.selectedCards[0], 8 };
                player.effectResist += 2;
                break;
            case 8:
                parameters = new object[] { player.selectedCards[0], 8 };
                player.effectResist += 3;
                break;
            case 9:
                parameters = new object[] { player.selectedCards[0], 8 };
                player.effectResist += 4;
                break;
            case 10:
                player.permanentlyEffects.Add(MaxEffect);
                break;

        }
         player.parametersOfEffect.Add(parameters);
    }

    public void ExecuteDefenseAbility(Entity entity, Entity enemy, int amount)
    {
        Debug.Log("Habilidade Defesa da Esperança usada");
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite da Esperança não encontrado no caminho: " + spritePath);

        return cardSprite;
    }

    private void Buff(params object[] objs)
    {
        CardBase card = (CardBase)objs[0];
        card.Damage += (int)objs[1];
    }

    private void MaxEffect(Entity player)
    {
        Buff(new object[] { player.selectedCards[0], 3 });
        player.health.Heal(4);
    }
}
