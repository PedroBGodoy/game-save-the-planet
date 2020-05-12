using System.Collections;

public class GameOverState : GameState
{
    public GameOverState(GameManager _manager) : base(_manager) { }

    public override void Start()
    {
        manager.HUD.GameOver();
        manager.Spawner.DestroyAllSpawnedObjects();
        manager.Spawner.StopSpawner();
        manager.Camera.MoveCameraTo(manager.GameSettings.cam_inMenuPosition);
    }

    public override void Menu()
    {
        manager.GameStateMachine.SetState(new MenuState(manager));
    }

    public override void Play()
    {
        manager.GameStateMachine.SetState(new PlayState(manager));
    }
}
