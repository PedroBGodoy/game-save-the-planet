using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State currentState;
    private GameManager manager;

    public void Initialize(GameManager _manager)
    {
        manager = _manager;
        SetState(new MenuState(manager));
    }

    public void SetState(State state)
    {
        currentState = state;
        StartCoroutine(currentState.Start());
    }

    public void OnMenuButton()
    {
        StartCoroutine(currentState.Menu());
    }

    public void OnPlayButton()
    {
        StartCoroutine(currentState.Play());
    }

    public void OnGameOver()
    {
        StartCoroutine(currentState.GameOver());
    }

    public void OnPauseButton()
    {
        StartCoroutine(currentState.Pause());
    }

    public void OnResumeButton()
    {
        StartCoroutine(currentState.Resume());
    }
}
