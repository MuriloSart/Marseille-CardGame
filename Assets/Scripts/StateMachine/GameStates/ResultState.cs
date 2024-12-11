using System.Collections;
using UnityEngine;

public class ResultState : StateBase
{
    private Entity entity;
    private TurnResult turnResult;
    private int damage;
    private int delay = 1;

    public override void OnStateEnter(params object[] objs)
    {
        entity = (Entity)objs[0];
        damage = (int)objs[1];
        turnResult = (TurnResult)objs[2];

        CoroutineRunner.Instance.StartCustomCoroutine(ActionsDelay());
    }

    private IEnumerator ActionsDelay()
    {
        EffectManager.Instance.GuiltDebuff();

        yield return new WaitForSeconds(delay);

        turnResult.DamageTurn(entity, damage);

        yield return new WaitForSeconds(delay);

        EffectManager.Instance.RemoveAllEffects(entity);
        CardsManager.Instance.DiscardSelected();
        GameStateManager.Instance.OnDealing();
    }
}