using UnityEngine;

public class FSM_Stage : MonoBehaviour
{
    public enum BattleStates
    {
        CARD_VALUE,
        CARD_EFFECT
    }

    public StateMachine<BattleStates> stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine<BattleStates>();
        stateMachine.Init();

        stateMachine.RegisterStates(BattleStates.CARD_VALUE, new ValueStage());
        stateMachine.RegisterStates(BattleStates.CARD_EFFECT, new EffectStage());

    }

    private void Update()
    {
        stateMachine.Update();
    }
}
