using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player enemy;
    public HealthBase health;
    public GameObject layoutCards;
    public List<GameObject> cards;

    public void Damage(int damage, string type)
    {
        if (enemy.cards.Count > 0)
        {
            if (enemy.cards != null && enemy.cards[0].GetComponent<CardBase>().currentElement.ToString() == type)
                damage -= enemy.cards[0].GetComponent<CardBase>().dmg;
        }
        enemy.health.Damage(damage);
    }

    public void AcquiringCards()
    {
        foreach (var card in cards) 
        {
            card.GetComponent<CardBase>().Acquire(this);
            card.transform.SetParent(layoutCards.transform);
        }
    }

    public void OnClick(GameObject item)
    {
        cards.Add(item);
    }
}
