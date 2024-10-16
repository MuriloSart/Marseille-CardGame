using UnityEngine;

public class GuiltCard : CardBase
{
    private IAbilityCard _ability;

    public GuiltCard()
    {
        _ability = new GuiltAbility();
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
