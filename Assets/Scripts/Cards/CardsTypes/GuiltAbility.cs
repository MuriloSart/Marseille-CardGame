using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiltAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/GuiltImg";

    public void ExecuteAbility()
    {
        Debug.Log("Habilidade Culpa usada");
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite da Culpa não encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}
