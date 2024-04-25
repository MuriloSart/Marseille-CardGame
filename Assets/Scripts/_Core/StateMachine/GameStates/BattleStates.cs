using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStates : StateBase
{

}

public class DealingState : BattleStates
{
    private Player player;
    private Player enemy;
    private CardPack pack;
    private int _currentBattle;
    private FSM_Battle battleState;

    public override void OnStateEnter(params object[] objs)
    {
        if(objs == null || objs.Length == 0) return;
        base.OnStateEnter(objs);
        player = (Player)objs[0];
        enemy = (Player)objs[1];
        pack = (CardPack)objs[2];
        battleState = (FSM_Battle)objs[3];
        
        player.state = Player.PlayerStates.DONTATTACK;
        _currentBattle = GameManager.DealingCards(player, enemy, pack);

        if(_currentBattle == 1)
        {
            battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.ATTACKING, player, enemy);
        }
        else
            battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.DEFENSE, player, enemy);
    }
}

public class AttackingState : BattleStates
{
    private Player player;
    private Player enemy;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        if (objs == null || objs.Length < 2)
        {
            Debug.Log("AttackingState: Não há parâmetros suficientes");
            return;
        }
        player = (Player)objs[0];
        enemy = (Player)objs[1];
        enemy.state = Player.PlayerStates.DONTATTACK;
        player.state = Player.PlayerStates.ATTACK;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();
        var card = enemy.cards[UnityEngine.Random.Range(0, enemy.cards.Count)].GetComponent<CardBase>();
        if (player.selectedCard)
        {
            Debug.Log("entrou");
            enemy.state = Player.PlayerStates.ATTACK;
            enemy.OnClick(card);
        }
    }
}

public class DefenseState : BattleStates
{
    private Player player;
    private Player enemy;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        if (objs == null || objs.Length == 0)
        {
            Debug.Log("DefenseState: Não há parâmetros suficientes");
            return;
        }
        player = (Player)objs[0];
        enemy = (Player)objs[1];
        enemy.state = Player.PlayerStates.ATTACK;
        player.state = Player.PlayerStates.DONTATTACK;

        var card = enemy.cards[UnityEngine.Random.Range(0, enemy.cards.Count)].GetComponent<CardBase>();
        enemy.OnClick(card);
    }

    public override void OnStateStay()
    {
        base.OnStateStay();
        if (enemy.selectedCard)
            player.state = Player.PlayerStates.ATTACK;
    }
}
