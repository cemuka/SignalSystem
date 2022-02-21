```c#
//  Sample usage
public static class Signaling
{
    ...
    public static readonly Signal       OnGameInit      = new Signal();
    public static readonly Signal<int>  OnPlayerScore   = new Signal<int>();    //newScore
    ...
}

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Signaling.OnGameInit.Invoke();
            
        ...
        Signaling.OnPlayerScore.Invoke(10);
        ...
    }
}

public class SomeView : MonoBehaviour
{
    private void Start()
    {
        Signaling.OnGameInit.AddListener(Initialize);
        Signaling.OnPlayerScore.AddListener(OnScore);
    }

    private void OnDestroy()
    {
        Signaling.OnGameInit.RemoveListener(Initialize);
        Signaling.OnPlayerScore.RemoveListener(OnScore);
    }

    private void Initialize()
    {
        //  display 
    }

    private void OnScore(int newScore)
    {
        //  update ui
    }
}
```