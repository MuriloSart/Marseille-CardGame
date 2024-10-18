using UnityEngine;

public class HopeAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/HopeImg";

    public void ExecuteAttackAbility(Entity player, Entity enemy, int amount)
    {
        Debug.Log("Habilidade Ataque da Esperan�a usada");
    }

    public void ExecuteDefenseAbility(Entity entity, Entity enemy, int amount)
    {
        Debug.Log("Habilidade Defesa da Esperan�a usada");
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite da Esperan�a n�o encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}
