Define your signals, up to 3 arguments.

```csharp
public class PlayerScore : Signal<int> {}
public class PlayerWin   : Signal {}
```

Register on initialize. Unregistered signal will raise an error.

```csharp
public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int winScore = 10;

    private void Start()
    {
        Signals.Register<PlayerScore>();
        Signals.Register<PlayerWin>();
    }

    private void UpdatePlayerScore()
    {
        score += 1;
        Signals.Get<PlayerScore>().Invoke(score);

        if(score >= winScore)
        {
            Signals.Get<PlayerWin>().Invoke();
        }
    }
}
```

Listen changes in any place, like ui

```csharp
public class ScoreUI : MonoBehaviour
{
    private void Start()
    {
        Signals.Get<PlayerScore>().AddListener(OnScore);
        Signals.Get<PlayerWin>().AddListener(OnWin);
    }

    private void OnDestroy()
    {
        Signals.Get<PlayerScore>().RemoveListener(OnScore);
        Signals.Get<PlayerWin>().RemoveListener(OnWin);
    }

    private void OnScore(int score)
    {
        //  update ui
    }

    private void OnWin()
    {
        //  show end game panel
    }
}
```

Additionally, it could be possible to make a generalized workflow.

```csharp
public class UISignals : Signal<UISignal> {}

public class UISignal
{
    public UISignalType type;
    public Dictionary<string, object> container;

    public UISignal(UISignalType type)
    {
        this.type = type;
        this.container = new Dictionary<string, object>();
    }

    public UISignal Add(string key, object value)
    {
        container.Add(key, value);
        return this;
    }

    public void Invoke()
    {
        Signals.Get<UISignals>().Invoke(this);
    }
}

public enum UISignalType
{
    PlayerGoldUpdated,
    PlayerDied,
    PlayerWon,
    MonsterSpawned
}
```
Then it would be used like fluent api

```csharp

private void PlayerDied()
{
    new UISignal(UISignalType.PlayerDied)
                                .Add("id", PLAYER_ID)
                                .Add("score", GetScore())
                                .Invoke();
}


```

Later, listeners will be notified

```csharp

private void Start()
{
    Signals.Get<UISignals>().AddListener(SignalListener);
}

private void SignalListener(UISignal data)
{
    if(data.type == UISignalType.PlayerDied)
    {
        //  handle event
    }
}


```

