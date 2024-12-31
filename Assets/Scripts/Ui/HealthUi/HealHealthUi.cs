using System.Threading.Tasks;

public class HealHealthUi
{
    private readonly int delay = 2000;

    public async void TextAtualize(HealthUi healthText, int heal)
    {
        healthText.healthText.text = $"{healthText.entityTarget.health.CurrentLife}";

        await Task.Delay(delay);

        healthText.healthText.text = $"{healthText.entityTarget.health.CurrentLife}";
    }
}
