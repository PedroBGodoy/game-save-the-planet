using System.Collections;

public class GameOverState : State
{
    public GameOverState(GameManager _manager) : base(_manager) { }

    public override IEnumerator Start()
    {
        manager.HUD.GameOver();
        manager.Spawner.StopAllObjectsMovement();
        manager.Spawner.StopSpawner();
        manager.Camera.MoveCameraTo(manager.GameSettings.cam_inMenuPosition);
        yield break;
    }

    public override IEnumerator Menu()
    {
        manager.Spawner.DestroyAllSpawnedObjects();
        manager.StateMachine.SetState(new MenuState(manager));
        yield break;
    }

    public override IEnumerator Play()
    {
        manager.Spawner.DestroyAllSpawnedObjects();
        manager.StateMachine.SetState(new PlayState(manager));
        yield break;
    }
}
