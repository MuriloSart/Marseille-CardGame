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
        Debug.Log(objs.Length);
        player = (Player)objs[0];
        enemy = (Player)objs[1];
        pack = (CardPack)objs[2];
        battleState = (FSM_Battle)objs[3];
        
        player.state = Player.PlayerStates.DONTATTACK;
        _currentBattle = GameManager.DealingCards(player, enemy, pack);

        if(_currentBattle == 1)
        {
            battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.ATTACKING, player);
        }
        else
            battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.DEFENSE, player);
    }
}

public class AttackingState : BattleStates
{
    private Player player;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        if (objs == null || objs.Length == 0)
        {
            Debug.Log("AttackingState: Não há parâmetros suficientes");
            return;
        }
        player = (Player)objs[0];
        player.state = Player.PlayerStates.ATTACK;
    }
}

public class DefenseState : BattleStates
{
    private Player player;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        if (objs == null || objs.Length == 0)
        {
            Debug.Log("DefenseState: Não há parâmetros suficientes");
            return;
        }
        player = (Player)objs[0];
        player.state = Player.PlayerStates.DONTATTACK;
    }
}
