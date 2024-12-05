public class Damage : IDamage
{
    public void Deal(Entity entity, int damage)
    {
        if (damage < 0) return;
        entity.Health.CurrentLife -= damage;
    }
}
