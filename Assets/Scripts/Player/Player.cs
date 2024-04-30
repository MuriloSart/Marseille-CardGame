using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Deck On Hand")]
    public List<GameObject> cards;
    public GameObject layoutCards;
    public GameObject SelectedPos;
    [HideInInspector]public CardBase cardSelected;

    [Header("Health")]
    public HealthBase health;
    public TextMeshProUGUI lifeTextValue;

    [Header("Decks")]
    public Discard discard;
    public CardPack pack;

    [Header("Enemy")]
    public Player enemy;

    [Header("Player Stats")]
    public PlayerStates state = PlayerStates.ATTACK;
    [HideInInspector] public bool selectedCard = false;

    [Header("Duration Time Animation")]
    public int durationAnimation = 1;

    //private
    private bool showDamage = false;
    private int damageDone;

    public enum PlayerStates
    {
        ATTACK,
        DONTATTACK
    }

    private void Damage(int damage, string type)
    {
        if (enemy.cards.Count > 0)
        {
            if (type == "Paus" && enemy.cardSelected.currentElement.ToString() == "Copas")//Attack Comparison
                damage *= 2;
            else if (type == "Copas" && enemy.cardSelected.currentElement.ToString() == "Espadas")
                damage *= 2;
            else if (type == "Espadas" && enemy.cardSelected.currentElement.ToString() == "Ouro")
                damage *= 2;
            else if (type == "Ouro" && enemy.cardSelected.currentElement.ToString() == "Paus")
                damage *= 2;
            else if (type == "Copas" && enemy.cardSelected.currentElement.ToString() == "Paus")//Defense Comparison
                damage /= 2;
            else if (type == "Espadas" && enemy.cardSelected.currentElement.ToString() == "Copas")
                damage /= 2;
            else if (type == "Ouro" && enemy.cardSelected.currentElement.ToString() == "Espadas")
                damage /= 2;
            else if (type == "Paus" && enemy.cardSelected.currentElement.ToString() == "Ouro")
                damage /= 2;

            damage -= enemy.cardSelected.dmg;
            if(damage < 0) damage = 0;
            DiscardingCards(enemy.cards, 0);
        }
        enemy.damageDone = damage;
        enemy.health.Damage(damage);
        StartCoroutine(CDDamageShowed(3));  
    }

    private void Start()
    {
        lifeTextValue.text = this.name + "Health:" + health.CurrentLife.ToString();
    }

    private void Update()
    {
        if(!showDamage)
            lifeTextValue.text = this.name + "Health:" + health.CurrentLife.ToString();
        else
            lifeTextValue.text = this.name + "Health:" + health.CurrentLife.ToString() + " - " + damageDone;
    }

    private void SelectingCard(CardBase card)
    {
        card.transform.DOMove(SelectedPos.transform.position, durationAnimation);
        StartCoroutine(DelayToSelect());
    }

    public void AcquiringCards()
    {
        int index = 1;
        foreach (var card in cards) 
        {
            card.GetComponent<CardBase>().Acquire(this);
            StartCoroutine(TimeToAnimation(card, index));
            index += 2;
        }
    }

    public void DamageTurn()
    {
        Damage(cardSelected.dmg, cardSelected.currentElement.ToString());
        DiscardingCards(cards, 0);
    }

    public void OnClick(CardBase cardClicked)
    {
        if (state == PlayerStates.DONTATTACK)
            return;

        cardSelected = cardClicked;

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

    IEnumerator TimeToAnimation(GameObject card, int i)
    {
        card.transform.DOMove(CalcularPosicaoFinal(layoutCards.GetComponent<HorizontalLayoutGroup>(), i), durationAnimation);
        yield return new WaitForSeconds(durationAnimation);
        card.transform.SetParent(layoutCards.transform);
    }

    IEnumerator CDDamageShowed(int cd)
    {
        enemy.showDamage = true;
        yield return new WaitForSeconds(cd);
        enemy.showDamage = false;
    }

    Vector2 CalcularPosicaoFinal(HorizontalLayoutGroup layoutGroup, int i)
    {
        Vector2 posicaoFinal = layoutGroup.transform.position;

        float largura = layoutGroup.gameObject.GetComponent<RectTransform>().rect.width;

        float StartPosition = posicaoFinal.x - (largura / 2);

        StartPosition += layoutGroup.padding.right;

        posicaoFinal.x = StartPosition + ((largura / 10) * i);
        return posicaoFinal;
    }
}
