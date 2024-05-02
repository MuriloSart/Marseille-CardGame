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
    public Deck pack;

    [Header("Enemy")]
    public Player enemy;

    [Header("Player Stats")]
    public PlayerStates state = PlayerStates.ATTACK;
    [HideInInspector] public bool selectedCard = false;

    [Header("Duration Time Animation")]
    public int durationAnimation = 1;

    //privates
    private bool _showDamage = false;
    private int _damageDone;

    public enum PlayerStates
    {
        ATTACK,
        DONTATTACK
    }

    private void Start()
    {
        lifeTextValue.text = this.name + "Health:" + health.CurrentLife.ToString();
    }

    private void Update()
    {
        if (!_showDamage)
            lifeTextValue.text = this.name + "Health:" + health.CurrentLife.ToString();
        else
            lifeTextValue.text = this.name + "Health:" + health.CurrentLife.ToString() + " - " + _damageDone;
    }

    #region Damage

    public void OnClick(CardBase cardClicked)
    {
        if (state == PlayerStates.DONTATTACK) return;

        cardSelected = cardClicked;

        SelectingCard(cardClicked);

        state = PlayerStates.DONTATTACK;
    }

    private void Damage(int damage)
    {
        if(enemy.cardSelected.currentElement == cardSelected.currentStrengthness)
            damage *= 2;
        else if(enemy.cardSelected.currentElement == cardSelected.currentWeakness)
            damage /= 2;

        damage -= enemy.cardSelected.dmg;
        if(damage < 0) damage = 0;
        enemy.DiscardingCards(enemy.cards.IndexOf(enemy.cardSelected.gameObject));

        enemy._damageDone = damage;
        enemy.health.Damage(damage);
        StartCoroutine(DamageCDShowed(3));  
    }

    public void DamageTurn()
    {
        Damage(cardSelected.dmg);
        DiscardingCards(cards.IndexOf(cardSelected.gameObject));
    }

    #endregion

    #region Manipulating Cards

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

    private void DiscardingCards(int index)
    {
        StartCoroutine(DelayToDiscard(cards[index]));
        cards.RemoveAt(index);
    }

    IEnumerator DelayToDiscard(GameObject card)
    {
        card.transform.DOMove(discard.transform.position, durationAnimation);
        yield return new WaitForSeconds(durationAnimation);
        discard.AcquiringCards(card);
    }

    private void SelectingCard(CardBase card)
    {
        card.transform.DOMove(SelectedPos.transform.position, durationAnimation);
        StartCoroutine(DelayToSelect());
    }

    IEnumerator DelayToSelect()
    {
        yield return new WaitForSeconds(durationAnimation);
        selectedCard = true;
    }

    #endregion

    #region Animations

    IEnumerator TimeToAnimation(GameObject card, int i)
    {
        card.transform.DOMove(CalcularPosicaoFinal(layoutCards.GetComponent<HorizontalLayoutGroup>(), i), durationAnimation);
        yield return new WaitForSeconds(durationAnimation);
        card.transform.SetParent(layoutCards.transform);
    }

    IEnumerator DamageCDShowed(int cd)
    {
        enemy._showDamage = true;
        yield return new WaitForSeconds(cd);
        enemy._showDamage = false;
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
    #endregion
}
