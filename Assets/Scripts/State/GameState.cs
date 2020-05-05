using System.Collections;

public abstract class GameState
{
    protected readonly GameManager manager;

    public GameState(GameManager _manager)
    {
        manager = _manager;
    }

    public virtual void Start() { }

    public virtual void Menu() { }

    public virtual void Play() { }

    public virtual void GameOver() { }

    public virtual void Pause() { }

    public virtual IEnumerator Resume()
    {
        yield break;
    }

}
