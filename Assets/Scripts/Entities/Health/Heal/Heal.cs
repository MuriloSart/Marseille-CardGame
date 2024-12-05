public class Heal : IHeal
{
    public void Restore(Entity entity, int heal)
    {
        if (heal <= 0) return;
        entity.Health.CurrentLife += heal;
    }
}
