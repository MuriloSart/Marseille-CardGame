using DG.Tweening;
using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [Header("Entities Reference")]
    public Player player;
    public Player enemy;
    public int maxCardNumber = 7;

    [Header("State Change Delay")]
    public int dealingDelay = 1;
    public int resetDeckDelay = 1;

    [Header("Packs")]
    public Deck deck;
    public Discard discard;

    [Header("Finite State Machine")]
    public FSM_Battle battleState;

    //privates
    private static int _currentBattle = 0;
    private static bool _resetDeck = false;

    private void Start()
    {
        OnDealing();
    }

    private void Update()
    {
        CheckingSelecteds();
        if (deck.cards.Count == 0 || deck.cards == null)
            if (battleState.stateMachine.CurrentState.ToString() != "ResetDeckState")
                StartCoroutine(DelayToReset());
        if(_resetDeck)
        {
            OnDealing();
            _resetDeck = false;
        }
    }

    public void CheckingSelecteds()
    {
        if(player.selectedCard && enemy.selectedCard)
        {
            if(_currentBattle == 0) enemy.DamageTurn();
            else if(_currentBattle == 1) player.DamageTurn();
            OnDealing();
            player.selectedCard = false;
            enemy.selectedCard = false;
        }
    }

    #region Dealing Cards

    public void OnDealing()
    {
        battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.DEALING, player, enemy, deck, battleState, dealingDelay);
    }

    public int DealingCards(Player player, Player enemy, Deck pack)
    {
        DealToPlayer(player, pack);
        DealToPlayer(enemy, pack);

        if (_currentBattle == 0)
            _currentBattle = 1;
        else
            _currentBattle = 0;
        return _currentBattle;
    }

    public void DealToPlayer(Player player, Deck pack)
    {
        int amountDealing = maxCardNumber - player.cards.Count;
        for (int i = 0; i < amountDealing; i++)
        {
            int index = UnityEngine.Random.Range(0, pack.cards.Count);
            player.cards.Add(pack.cards[index]);
            pack.cards.RemoveAt(index);
        }
        player.AcquiringCards();
    }

    #endregion

    #region ResetDeck

    public void ResetDeck(Discard discard, Deck deck,int indexArray, float delay)
    {
        if (indexArray < 0)
        {
            _resetDeck = true;
            return;
        }
        Debug.Log(indexArray);
        GameObject card = discard.discardPack[indexArray];

        card.transform.DOMove(deck.transform.position, delay);
        deck.cards.Add(card);
        discard.discardPack.Remove(card);

    }

    private IEnumerator DelayToReset()
    {
        yield return new WaitForSeconds(resetDeckDelay);
        battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.RESETDECK, discard, deck);
    }

    #endregion
}
