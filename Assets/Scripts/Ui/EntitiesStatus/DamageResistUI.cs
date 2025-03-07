using TMPro;
using UnityEngine;

public class DamageResistUI : MonoBehaviour
{
    public TextMeshProUGUI damageResistUi;

    private Entity entity;

    private void Start()
    {
        entity = FindObjectOfType<Entity>();
        damageResistUi.text = entity.DamageResist.ToString();
    }

    public void AtualizeText()
    {
        damageResistUi.text = entity.DamageResist.ToString();
    }
}
