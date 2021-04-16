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
        Signals.Get<TestSignal>().AddListener(OnScore);
        Signals.Get<TestSignal>().AddListener(OnWin);
    }

    private void OnDestroy()
    {
        Signals.Get<TestSignal>().RemoveListener(OnScore);
        Signals.Get<TestSignal>().RemoveListener(OnWin);
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