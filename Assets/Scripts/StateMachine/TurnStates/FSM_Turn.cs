using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Turn : MonoBehaviour
{
    public enum BattleStates
    {
        PLAYER_TURN,
        ENEMY_TURN
    }

    public StateMachine<BattleStates> stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine<BattleStates>();
        stateMachine.Init();

        stateMachine.RegisterStates(BattleStates.PLAYER_TURN, new PlayerTurnState());
        stateMachine.RegisterStates(BattleStates.ENEMY_TURN, new EnemyTurnState());
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
