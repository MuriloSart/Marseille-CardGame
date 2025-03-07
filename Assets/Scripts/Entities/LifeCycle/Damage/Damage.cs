using UnityEngine;

public class Damage : MonoBehaviour, IDamage
{
    public void Deal(Entity enemy, int damage)
    {
        if (damage < 0) return;

        if(enemy.DamageResist < damage)
        {
            damage -= enemy.DamageResist;
            enemy.DamageResist = 0;
            enemy.health.CurrentLife -= (damage - enemy.DamageResist);
            enemy.healthUi.DamageUi(damage);
        }
        else
            enemy.healthUi.DamageUi(0);
    }
}
