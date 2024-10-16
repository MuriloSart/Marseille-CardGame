using UnityEngine;

public class DeathAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/DeathImg";

    public void ExecuteAbility()
    {
        Debug.Log("Habilidade Morte usada");
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite da Morte não encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}
