using System;
using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //Players
    [Header("Entities Reference")]
    public Player player;
    public Player enemy;

    [Header("State Change Delay")]
    public int dealingDelay = 1;

    //Packs
    [Header("Packs")]
    public CardPack cardPack;
    public Discard discard;

    [Header("Finite State Machine")]
    public FSM_Battle battleState;

    private static int _currentBattle = 0;

    private void Start()
    {
        OnDealing();
    }

    private void Update()
    {
        CheckingSelecteds();
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
    IEnumerator DelayDealingState()
    {
        yield return new WaitForSeconds(1);
        battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.DEALING, player, enemy, cardPack, battleState, dealingDelay);
    }
    public void OnDealing()
    {
        StartCoroutine(DelayDealingState());
    }

    public static void DealingPlayers(Player player, CardPack pack)
    {
        int amountDealing = 5 - player.cards.Count;
        for (int i = 0; i < amountDealing; i++)
        {
            int index = UnityEngine.Random.Range(0, pack.cards.Count);
            player.cards.Add(pack.cards[index]);
            pack.cards.RemoveAt(index);
        }
        player.AcquiringCards();
    }

    public static int DealingCards(Player player, Player enemy, CardPack pack)
    {
        DealingPlayers(player, pack);
        DealingPlayers(enemy, pack);

        if (_currentBattle == 0)
        {
            _currentBattle = 1;
        }
        else
            _currentBattle = 0;
        return _currentBattle;

    }
}
