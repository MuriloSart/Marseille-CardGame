using UnityEngine;

public class HopeAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/HopeImg";

    public void ExecuteAttackAbility(Entity player, Entity enemy, int amount)
    {
        Debug.Log("Habilidade Ataque da Esperança usada");
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
}
