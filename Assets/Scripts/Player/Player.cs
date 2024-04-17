using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player enemy;
    public HealthBase health;
    public GameObject layoutCards;
    public List<GameObject> cards;
    public CardPack pack;
    public Discard discard;

    public void Damage(int damage, string type)
    {
        if (enemy.cards.Count > 0)
        {
            if (type == "Paus" && enemy.cards[0].GetComponent<CardBase>().currentElement.ToString() == "Copas")
                damage *= 2;
            else if (type == "Copas" && enemy.cards[0].GetComponent<CardBase>().currentElement.ToString() == "Espadas")
                damage *= 2;
            else if (type == "Espadas" && enemy.cards[0].GetComponent<CardBase>().currentElement.ToString() == "Ouro")
                damage *= 2;
            else if (type == "Ouro" && enemy.cards[0].GetComponent<CardBase>().currentElement.ToString() == "Paus")
                damage *= 2;

            damage -= enemy.cards[0].GetComponent<CardBase>().dmg;
            DiscardingCards(enemy.cards, 0);
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

    public void OnClick()
    {
        if (cards.Count > 0)
        {
            Damage(cards[0].GetComponent<CardBase>().dmg, cards[0].GetComponent<CardBase>().currentElement.ToString());
            DiscardingCards(cards, 0);
        }
    }

    public void DiscardingCards(List<GameObject> cards, int index)
    {
        discard.AcquiringCards(cards[index]);
        cards.RemoveAt(index);
    }
}
