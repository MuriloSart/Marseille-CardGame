using System.Collections;
using UnityEngine;

public class DamageHealthUi : MonoBehaviour
{
    private static int delay = 2;
    public static void textAtualize(HealthUi healthText, int damage)
    {
        CoroutineHelper.Instance.RunCoroutine(DelayToDiscard(healthText, damage));
    }

    private static IEnumerator DelayToDiscard(HealthUi healthText, int damage)
    {
        healthText.healthText.text = $"{healthText.entityTarget.name} Health : {healthText.entityTarget.health.CurrentLife} - {damage}";
        yield return new WaitForSeconds(delay);
        healthText.healthText.text = $"{healthText.entityTarget.name} Health : {healthText.entityTarget.health.CurrentLife}";
    }
}
