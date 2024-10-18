using UnityEngine;
internal class LoveAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/LoveImg";

    public void ExecuteAttackAbility(Entity player, Entity enemy, int amount)
    {
        Debug.Log("Habilidade Ataque do Amor usada");
        switch (amount)
        {
            case 1:
                player.health.Heal(3);
                break;
            case 2:
                player.health.Heal(3);
                break;
            case 3:
                player.health.Heal(3);
                break;
            case 4:
                player.health.Heal(5);
                break;
            case 5:
                player.health.Heal(5);
                break;
            case 6:
                player.health.Heal(5);
                break;
            case 7:
                player.health.Heal(player.health.startLife/2);
                break;
            case 8:
                player.health.Heal(player.health.startLife / 2);
                break;
            case 9:
                player.health.Heal(player.health.startLife / 2);
                break;
            case 10:
                player.health.Heal(player.health.startLife);
                break;
        }
    }

    public void ExecuteDefenseAbility(Entity player, Entity enemy, int amount)
    {
        Debug.Log("Habilidade Defesa do Amor usada");
        switch (amount)
        {
            case 1:
                enemy.selectedCards[0].dmg -= 3;
                break;
            case 2:
                enemy.selectedCards[0].dmg -= 3;
                break;
            case 3:
                enemy.selectedCards[0].dmg -= 3;
                break;
            case 4:
                enemy.selectedCards[0].dmg -= 5;
                break;
            case 5:
                enemy.selectedCards[0].dmg -= 5;
                break;
            case 6:
                enemy.selectedCards[0].dmg -= 5;
                break;
            case 7:
                enemy.selectedCards[0].dmg = 0;
                break;
            case 8:
                enemy.selectedCards[0].dmg = 0;
                break;
            case 9:
                enemy.selectedCards[0].dmg = 0;
                break;
            case 10:
                player.health.startLife += 10;
                break;
        }
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite do Amor não encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}