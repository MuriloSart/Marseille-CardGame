using TMPro;
using UnityEngine;

public class EffectResistUI : MonoBehaviour
{
    public TextMeshProUGUI effectResistUi;

    private Entity entity;

    private void Start()
    {
        entity = FindObjectOfType<Entity>();
        effectResistUi.text = entity.EffectResist.ToString();
    }

    public void AtualizeText()
    {
        effectResistUi.text = entity.EffectResist.ToString();
    }
}