using UnityEngine;

public class FSM_Turn : MonoBehaviour
{
    public enum BattleStates
    {
        IDLE,
        PLAYER_TURN,
        ENEMY_TURN
    }

    public StateMachine<BattleStates> stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine<BattleStates>();
        stateMachine.Init();

        stateMachine.RegisterStates(BattleStates.IDLE, new TurnStates());
        stateMachine.RegisterStates(BattleStates.PLAYER_TURN, new PlayerTurnState());
        stateMachine.RegisterStates(BattleStates.ENEMY_TURN, new EnemyTurnState());

        stateMachine.SwitchState(BattleStates.IDLE);
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
