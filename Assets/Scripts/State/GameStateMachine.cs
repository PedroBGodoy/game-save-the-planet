using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    private GameState currentState;
    private GameManager manager;

    public void Initialize(GameManager _manager)
    {
        manager = _manager;
        SetState(new MenuState(manager));
    }

    public void SetState(GameState GameState)
    {
        currentState = GameState;
        currentState.Start();
    }

    private void Update() => currentState.Update();

    public void OnMenuButton() => currentState.Menu();

    public void OnPlayButton() => currentState.Play();

    public void OnGameOver() => currentState.GameOver();

    public void OnPause() => currentState.Pause();
    public void OnPauseButton() => currentState.Pause();

    public void OnResumeButton() => currentState.Resume();

    public void OnLevelChange(Level level) => currentState.ChangeLevel(level);

    public void OnMeteorCollideWithPlanet() => currentState.CheckPlanetHealth();

}
