using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("LoseScreen")]
    [SerializeField] private int screen = 3;

    [Header("Deck On Hand")]
    public List<GameObject> cards;
    public GameObject layoutCards;
    public GameObject SelectedPos;
    [HideInInspector]public List<CardBase> selectedCards;

    [Header("Health")]
    public HealthBase health;
    public TextMeshProUGUI lifeTextValue;

    [Header("Decks")]
    public Discard discard;

    [Header("Enemy")]
    public Player enemy;
    
    [Header("Player Stats")]
    public PlayerStates state = PlayerStates.ATTACK;
    [HideInInspector] public bool selected = false;

    [Header("Duration Time Animation")]
    public int durationAnimation = 1;

    //privates
    private bool _showDamage = false;
    private int _damageDone;

    

    private void Start()
    {
        ShowingDamage();
    }

    private void Update()
    {
        ShowingDamageUpdate();
    }


    #region Dealing Damage
    public enum PlayerStates
    {
        ATTACK,
        DONTATTACK
    }

    public void OnClick(CardBase cardClicked)
    {
        if (state == PlayerStates.DONTATTACK) return;

        selectedCards.Add(cardClicked);

        SelectingCard(cardClicked);

        if(selectedCards.Count >= 2)
        {
            StartCoroutine(DelayToSelect());
            state = PlayerStates.DONTATTACK;
        }
    }

    private void Damage(int damage)
    {
        if(damage < 0) damage = 0;
        
        enemy._damageDone = damage;
        enemy.health.Damage(damage);
        StartCoroutine(DamageCDShowed(3));  
    }

    private void DiscardEnemyCards()
    {
        foreach (CardBase card in enemy.selectedCards)
        {
            enemy.DiscardingCards(enemy.cards.IndexOf(card.gameObject));
        }
    }

    public void DamageTurn()
    {
        foreach(var card in selectedCards)
        {
            Damage(card.dmg);
            DiscardingCards(cards.IndexOf(card.gameObject));
        }
        DiscardEnemyCards();
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
    }

    IEnumerator DelayToSelect()
    {
        yield return new WaitForSeconds(durationAnimation);
        selected = true;
    }

    #endregion

    #region Animations

    IEnumerator TimeToAnimation(GameObject card, int i)
    {
        card.transform.DOMove(CalcularPosicaoFinal(layoutCards.GetComponent<HorizontalLayoutGroup>(), i), durationAnimation);
        yield return new WaitForSeconds(durationAnimation);
        card.transform.SetParent(layoutCards.transform);
    }

    Vector2 CalcularPosicaoFinal(HorizontalLayoutGroup layoutGroup, int i)
    {
        Vector2 posicaoFinal = layoutGroup.transform.position;

        float largura = layoutGroup.gameObject.GetComponent<RectTransform>().rect.width;

        float StartPosition = posicaoFinal.x - (largura / 2);

        StartPosition += layoutGroup.padding.right;

        posicaoFinal.x = StartPosition + ((largura / (GameManager.Instance.maxCardNumber *2)) * i);
        return posicaoFinal;
    }

    #endregion

    #region Health Ui Manage
    private void ShowingDamage()
    {
        health.player = this;
        lifeTextValue.text = this.name + "Health:" + health.CurrentLife.ToString();
    }

    private void ShowingDamageUpdate()
    {
        if (!_showDamage)
            lifeTextValue.text = this.name + "Health:" + health.CurrentLife.ToString();
        else
            lifeTextValue.text = this.name + "Health:" + health.CurrentLife.ToString() + " - " + _damageDone;
    }

    IEnumerator DamageCDShowed(int cd)
    {
        enemy._showDamage = true;
        yield return new WaitForSeconds(cd);
        enemy._showDamage = false;
    }

    #endregion

    public void Lose()
    {
        SceneManager.LoadScene(screen);
    }
}
