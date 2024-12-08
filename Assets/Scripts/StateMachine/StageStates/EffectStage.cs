public class EffectStage : StageStates
{
    private Player player;
    private Enemy enemy;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        player = (Player)objs[0];
        enemy = (Enemy)objs[1];

        player.selected = false;
        enemy.selected = false;
        player.SelectedPosOption = 2;
        enemy.SelectedPosOption = 2;
    }
}