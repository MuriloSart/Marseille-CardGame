using System.Collections.Generic;

public class StateMachine<T> where T : System.Enum
{
    public Dictionary<T, StateBase> dictionaryState;

    public StateBase _currentState;

    public StateBase CurrentState
    {
        get { return _currentState; }
    }

    public void Init()
    {
        dictionaryState = new Dictionary<T, StateBase>();
    }

    public void RegisterStates(T typeEnum, StateBase state)
    {
        dictionaryState.Add(typeEnum, state);
    }

    public void SwitchState(T state, params object[] objs)
    {
        _currentState?.OnStateExit();

        _currentState = dictionaryState[state];

        _currentState?.OnStateEnter(objs);
    }

    public void Update()
    {
        _currentState?.OnStateStay();
    }   
}
