using UnityEngine;

public class PauseState : GameState
{
    public PauseState(GameManager _manager) : base(_manager) { }

    private bool isPaused = false;

    public override void Start()
    {
        isPaused = true;
        Time.timeScale = 0;
        manager.HUD.ShowPausePanel();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Resume();
    }

    public override void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        manager.HUD.HidePausePanel();

        manager.GameStateMachine.SetState(new PlayState(manager));
    }
}
