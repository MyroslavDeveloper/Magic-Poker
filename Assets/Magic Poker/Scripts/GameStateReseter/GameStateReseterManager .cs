using UnityEngine;

public class GameStateReseterManager : MonoBehaviour
{
    private void Awake()
    {
        GameStateReseter.LoadAll();
    }

    private void OnApplicationQuit()
    {
        GameStateReseter.SaveAll();
    }
}
