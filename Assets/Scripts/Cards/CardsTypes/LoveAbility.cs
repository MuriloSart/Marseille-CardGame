using UnityEngine;
internal class LoveAbility : IAbilityCard
{
    private readonly string spritePath = "Cards/LoveImg";


    public void ExecuteAbility()
    {
        Debug.Log("Habilidade Amor usada");
    }

    public Sprite Render()
    {
        Sprite cardSprite = Resources.Load<Sprite>(spritePath);

        if (cardSprite == null)
            Debug.LogError("Sprite do Amor não encontrado no caminho: " + spritePath);

        return cardSprite;
    }
}