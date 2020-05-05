using System.Collections;

public abstract class State
{
    protected readonly GameManager manager;

    public State(GameManager _manager)
    {
        manager = _manager;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Menu()
    {
        yield break;
    }

    public virtual IEnumerator Play()
    {
        yield break;
    }

    public virtual IEnumerator GameOver()
    {
        yield break;
    }

    public virtual IEnumerator Pause()
    {
        yield break;
    }

    public virtual IEnumerator Resume()
    {
        yield break;
    }

}
