#if UNITY_EDITOR
using System.Linq;
using UnityEditor;

[CustomEditor(typeof(FSM_Turn))]
public class TurnStatesEditor : Editor
{
    public bool showFoldout = true;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FSM_Turn fsm = (FSM_Turn)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("Turn States");

        if (fsm.stateMachine == null) return;

        if (fsm.stateMachine.CurrentState != null)
            EditorGUILayout.LabelField("Current State:", fsm.stateMachine.CurrentState.ToString());

        showFoldout = EditorGUILayout.Foldout(showFoldout, "Avaible State");

        if (showFoldout)
        {
            if (fsm.stateMachine.dictionaryState != null)
            {
                var keys = fsm.stateMachine.dictionaryState.Keys.ToArray();
                var vals = fsm.stateMachine.dictionaryState.Values.ToArray();
                for (int i = 0; i < keys.Length; i++)
                {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], vals[i]));
                }
            }

        }
    }
}
#endif
