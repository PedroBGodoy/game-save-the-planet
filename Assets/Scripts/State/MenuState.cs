using System.Collections;
using UnityEngine;

public class MenuState : State
{
    public MenuState(GameManager _manager) : base(_manager) { }

    public override IEnumerator Start()
    {
        manager.HUD.Menu();
        manager.Score.LoadScore();
        manager.Shield.ShieldMovement.BlockMovement();
        yield break;
    }

    public override IEnumerator Play()
    {
        manager.StateMachine.SetState(new PlayState(manager));
        yield break;
    }
}
