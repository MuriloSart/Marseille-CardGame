using UnityEngine;

public class HopeAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/HopeImg";

    public void ExecuteAttackAbility(Entity player, Entity enemy, int amount)
    {
        player.postEffectActived = true;
        player.postEffect = Buff;

        switch (amount)
        {
            case 1:
                player.postEffect(new object[] { player.selectedCards[0], 3 });
                break;
            case 2:
                player.postEffect(new object[] { player.selectedCards[0], 3 });
                break;
            case 3:
                player.postEffect(new object[] { player.selectedCards[0], 3 });
                break;
            case 4:
                player.postEffect(new object[] { player.selectedCards[0], 5 });
                break;
            case 5:
                player.postEffect(new object[] { player.selectedCards[0], 5 });
                break;
            case 6:
                player.postEffect(new object[] { player.selectedCards[0], 5 });
                break;
            case 7:
                player.postEffect(new object[] { player.selectedCards[0], 10 });
                break;
            case 8:
                player.postEffect(new object[] { player.selectedCards[0], 10 });
                break;
            case 9:
                player.postEffect(new object[] { player.selectedCards[0], 10 });
                break;
            case 10:
                player.health.Heal(player.health.startLife);
                break;
        }
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
}
