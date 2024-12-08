using UnityEngine;

public class Damage : MonoBehaviour, IDamage
{
    public void Deal(Entity entity, int damage)
    {
        if (damage < 0) return;

        entity.health.CurrentLife -= damage;
    }
}
