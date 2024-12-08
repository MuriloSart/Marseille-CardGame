using UnityEngine;

public class Enemy : Entity
{
    protected override void Init()
    {  
        base.Init(); 
        death.Screen = 4;
    }

    public void AutoSelect()
    {
        var card = cardsOnHand.cards[Random.Range(0, enemy.cardsOnHand.cards.Count - 1)].GetComponent<CardBase>();
        card.OnClick();
    }
}
