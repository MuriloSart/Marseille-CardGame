internal class ResultState : StateBase
{
    private Entity entity;
    private TurnResult turnResult;
    private int damage;

    public override void OnStateEnter(params object[] objs)
    {
        entity = (Entity)objs[0];
        damage = (int)objs[1];
        turnResult = (TurnResult)objs[2];

        turnResult.DamageTurn(entity, damage);
        EffectManager.Instance.RemoveAllEffects(entity);
        CardsManager.Instance.DiscardSelected();
        GameStateManager.Instance.OnDealing();
    }
}