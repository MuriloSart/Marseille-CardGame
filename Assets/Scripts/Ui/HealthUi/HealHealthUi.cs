using System.Collections;
using UnityEngine;

public static class HealHealthUi
{
    private static int delay = 2;
    public static void textAtualize(HealthUi healthText, int heal)
    {
        CoroutineHelper.Instance.RunCoroutine(DelayToDiscard(healthText, heal));
    }

    private static IEnumerator DelayToDiscard(HealthUi healthText, int heal)
    {
        healthText.healthText.text = $"{healthText.entityTarget.name} Health : {healthText.entityTarget.health.CurrentLife} + {heal}";
        yield return new WaitForSeconds(delay);
        healthText.healthText.text = $"{healthText.entityTarget.name} Health : {healthText.entityTarget.health.CurrentLife}";
    }
}
