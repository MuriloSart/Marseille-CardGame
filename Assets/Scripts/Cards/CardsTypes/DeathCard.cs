using UnityEngine;

public class DeathCard : CardBase
{
    private IAbilityCard _ability;

    public DeathCard()
    {
        _ability = new DeathAbility();
    }

    public override Sprite Render()
    {
        return _ability.Render();
    }

    public override void UseAbility()
    {
        _ability.ExecuteAbility();
    }
}
