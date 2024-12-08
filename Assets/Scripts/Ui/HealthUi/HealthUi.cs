using TMPro;
using UnityEngine;

public class HealthUi : MonoBehaviour
{
    public Entity entityTarget;
    public TextMeshProUGUI healthText;
    public int delayAnimation = 1;

    private void Start()
    {
        //healthText.text = $"{entityTarget.name} Health : {entityTarget.Health.CurrentLife}";
    }
}
