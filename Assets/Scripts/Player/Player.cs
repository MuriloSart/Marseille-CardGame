using System.Collections.Generic;
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
            if (enemy.cards[0].GetComponent<CardBase>().currentElement.ToString() == type)
                damage -= enemy.cards[0].GetComponent<CardBase>().dmg;
            else if (type == "Fire" && enemy.cards[0].GetComponent<CardBase>().currentElement.ToString() == "Earth")
                damage *= 2;
            else if (type == "Water" && enemy.cards[0].GetComponent<CardBase>().currentElement.ToString() == "Fire")
                damage *= 2;
            else if (type == "Earth" && enemy.cards[0].GetComponent<CardBase>().currentElement.ToString() == "Air")
                damage *= 2;
            else if (type == "Air" && enemy.cards[0].GetComponent<CardBase>().currentElement.ToString() == "Water")
                damage *= 2;
            else if( type == "Mana" && enemy.cards[0].GetComponent<CardBase>().currentElement.ToString() != "Mana")
                damage *= 2;
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
            discard.AcquiringCards(cards[0]);
            cards.RemoveAt(0);
        }
    }
}
