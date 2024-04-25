using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //Players
    public Player player;
    public Player enemy;

    //Packs
    public CardPack pack;
    public Discard Discard;
    public FSM_Battle battleState;

    private static int _currentBattle = 0;

    private void Start()
    {
        OnDealing();
    }

    public void OnDealing()
    {
        battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.DEALING, player, enemy, pack, battleState);
    }

    public static void DealingPlayers(Player player, CardPack pack)
    {
        for (int i = 0; i < 5; i++)
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
