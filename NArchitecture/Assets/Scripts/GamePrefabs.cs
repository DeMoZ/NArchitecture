using UnityEngine;

[CreateAssetMenu]
public class GamePrefabs : ScriptableObject
{
    public ClickCatcher ClickCatcherPrefab = default;
    
    public UIGameStateView UiGameStatePrefab = default;
    public ClickCubeView ClickCubePrefab = default;
}