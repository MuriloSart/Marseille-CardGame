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
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryState[state];

        if (_currentState != null) _currentState.OnStateEnter(objs);
    }

    public void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
    }   
}
