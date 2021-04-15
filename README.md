Define your signal, up to 3 arguments.

```csharp
public class PlayerScore : Signal<int> {}
```
Register on initialize. Unregistered signal will raise an error.

```csharp
public class ScoreManager : MonoBehaviour
{
    private void Start()
    {
        Signals.Register<PlayerScore>();
    }

    private void UpdatePlayerScore()
    {
        Signals.Get<TestSignal>().Invoke(5);
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
    }

    private void OnScore(int score)
    {
        //  update ui
    }
}
```