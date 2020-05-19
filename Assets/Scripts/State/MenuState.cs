public class MenuState : GameState
{
    public MenuState(GameManager _manager) : base(_manager) { }

    public override void Start()
    {
        manager.HUD.Menu();
        manager.ScoreController.LoadScore();

        manager.Shield.ShieldMovement.BlockMovement();
        manager.Camera.MoveCameraTo(manager.GameSettings.cam_inMenuPosition);
    }

    public override void Play() => manager.GameStateMachine.SetState(new PlayState(manager));
}
