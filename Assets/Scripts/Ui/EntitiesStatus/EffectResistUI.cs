using TMPro;
using UnityEngine;

public class EffectResistUI : MonoBehaviour
{
    public TextMeshProUGUI effectResistUi;

    private Entity entity;

    private void Start()
    {
        entity = GetComponent<Entity>();
        effectResistUi.text = entity.EffectResist.ToString();
    }

    public void AtualizeText()
    {
        effectResistUi.text = entity.EffectResist.ToString();
    }
}