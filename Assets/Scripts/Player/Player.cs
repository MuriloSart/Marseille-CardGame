using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public GameObject layoutCards;
    public List<GameObject> cards;
    public HealthBase health;
    public Discard discard;
    public CardPack pack;
    public Player enemy;
    public GameObject SelectedPos;
    public PlayerStates state = PlayerStates.ATTACK;
    public bool _selectedCard = false;

    //private
    private CardBase _cardSelected;

    public enum PlayerStates
    {
        ATTACK,
        DONTATTACK
    }

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

    private void SelectingCard(CardBase card)
    {
        _selectedCard = true;
        card.transform.DOMove(SelectedPos.transform.position, 1);
    }

    public void AcquiringCards()
    {
        foreach (var card in cards) 
        {
            card.GetComponent<CardBase>().Acquire(this);
            card.transform.SetParent(layoutCards.transform);
        }
    }

    public void OnClick(CardBase cardClicked)
    {
        if (state == PlayerStates.DONTATTACK)
            return;

        foreach(var card in cards)
        {
            if(card == typeof(CardBase).IsInstanceOfType(cardClicked))
            {
                _cardSelected = card.GetComponent<CardBase>();
            }
        }

        if (cards.Count > 0)
        {
            SelectingCard(_cardSelected);
            //Damage(_cardSelected.dmg, _cardSelected.currentElement.ToString());
            //DiscardingCards(cards, 0);
        }
    }

    public void DiscardingCards(List<GameObject> cards, int index)
    {
        discard.AcquiringCards(cards[index]);
        cards.RemoveAt(index);
    }
}
