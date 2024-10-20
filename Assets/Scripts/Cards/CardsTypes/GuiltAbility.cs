using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiltAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/GuiltImg";

    public void ExecuteAttackAbility(Entity player, Entity enemy, int amount)
    {
        Debug.Log("Habilidade Ataque da Culpa usada");
    }

    public void ExecuteDefenseAbility(Entity entity, Entity enemy, int amount)
    {
        Debug.Log("Habilidade Defesa da Culpa usada");
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite da Culpa não encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}
