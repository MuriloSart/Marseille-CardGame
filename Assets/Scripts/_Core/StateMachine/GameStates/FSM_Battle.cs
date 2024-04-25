using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Battle : MonoBehaviour
{
    public enum BattleStates
    {
        DEALING,
        ATTACKING,
        DEFENSE
    }

    public StateMachine<BattleStates> stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine<BattleStates>();
        stateMachine.Init();

        stateMachine.RegisterStates(BattleStates.DEALING, new DealingState());
        stateMachine.RegisterStates(BattleStates.ATTACKING, new AttackingState());
        stateMachine.RegisterStates(BattleStates.DEFENSE, new DefenseState());

        stateMachine.SwitchState(BattleStates.DEALING);
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
