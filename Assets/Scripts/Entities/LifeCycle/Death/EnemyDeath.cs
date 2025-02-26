namespace Entities.LifeCycle.Death
{
    class EnemyDeath : Death
    {
        public override void OnDeath()
        {
            base.OnDeath();
            GameManager.Instance.Win();
        }
    }
}
