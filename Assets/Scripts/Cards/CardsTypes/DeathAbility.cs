using UnityEngine;

public class DeathAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/DeathImg";

    public void ExecuteAttackAbility(Entity player, Entity enemy, int amount)
    {
        Debug.Log("Habilidade Ataque da Morte usada");
    }

    public void ExecuteDefenseAbility(Entity entity, Entity enemy, int amount)
    {
        Debug.Log("Habilidade Defesa da Morte usada");
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite da Morte não encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}
