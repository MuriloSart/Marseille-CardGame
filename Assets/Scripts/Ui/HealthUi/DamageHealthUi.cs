using System.Threading.Tasks;

public class DamageHealthUi
{
    private readonly int delay = 2000;

    public async void TextAtualize(HealthUi healthText, int damage)
    {
        healthText.healthText.text = $"{healthText.entityTarget.health.CurrentLife} - {damage}";

        await Task.Delay(delay);

        healthText.healthText.text = $"{healthText.entityTarget.health.CurrentLife}";
    }
}
