using UnityEngine;

public class HopeAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/HopeImg";

    public void ExecuteAbility()
    {
        Debug.Log("Habilidade Esperança usada");
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite da Esperança não encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}
