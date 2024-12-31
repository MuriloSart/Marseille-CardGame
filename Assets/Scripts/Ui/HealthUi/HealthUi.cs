using TMPro;
using UnityEngine;

public class HealthUi : MonoBehaviour
{
    public Entity entityTarget;
    public TextMeshProUGUI healthText;
    public int delayAnimation = 1;

    private DamageHealthUi damageUi;
    private HealHealthUi healUi;

    private void Start()
    {
        healUi = new HealHealthUi();
        damageUi = new DamageHealthUi();
        healthText.text = $"{entityTarget.health.CurrentLife}";
    }

    public void HealUi(int heal)
    {
        healUi.TextAtualize(this, heal);
    }

    public void DamageUi(int heal)
    {
        damageUi.TextAtualize(this, heal);
    }
}
