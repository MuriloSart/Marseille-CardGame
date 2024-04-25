using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Player : MonoBehaviour
{
    [Header("Deck On Hand")]
    public List<GameObject> cards;
    public GameObject layoutCards;
    public GameObject SelectedPos;

    [Header("Health")]
    public HealthBase health;

    [Header("Decks")]
    public Discard discard;
    public CardPack pack;

    [Header("Enemy")]
    public Player enemy;

    [Header("Player Stats")]
    public PlayerStates state = PlayerStates.ATTACK;
    public bool selectedCard = false;

    [Header("Duration Time Animation")]
    public int durationAnimation = 1;

    //private
    private CardBase _cardSelected;

    public enum PlayerStates
    {
        ATTACK,
        DONTATTACK
    }

    private void Damage(int damage, string type)
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
        card.transform.DOMove(SelectedPos.transform.position, durationAnimation);
        StartCoroutine(DelayToSelect());
    }

    public void AcquiringCards()
    {
        foreach (var card in cards) 
        {
            card.GetComponent<CardBase>().Acquire(this);
            card.transform.SetParent(layoutCards.transform);
        }
    }

    public void DamageTurn()
    {
        Damage(_cardSelected.dmg, _cardSelected.currentElement.ToString());
        DiscardingCards(cards, 0);
    }

    public void OnClick(CardBase cardClicked)
    {
        if (state == PlayerStates.DONTATTACK)
            return;

        _cardSelected = cardClicked;

        if (cards.Count > 0)
        {
            SelectingCard(cardClicked);
        }

        state = PlayerStates.DONTATTACK;
    }

    private void DiscardingCards(List<GameObject> cards, int index)
    {
        discard.AcquiringCards(cards[index]);
        cards.RemoveAt(index);
    }

    IEnumerator DelayToSelect()
    {
        yield return new WaitForSeconds(durationAnimation);
        selectedCard = true;
    }
}
