using UnityEngine;

public class EnterPoint : MonoBehaviour
{
    [Header("UI")] [SerializeField] private UIGameState _uiGameStatePrefab = default;
    [SerializeField] private ClickCatcher _clickCatcherPrefab = default;

    [Header("Scene")] [SerializeField] private ClickCube _clickCubePrefab = default;

    private Root _root;

    private void Start()
    {
        _root = new Root(new Root.Ctx
        {
            UiPrefab = _uiGameStatePrefab,
            ClickCatcher = _clickCatcherPrefab,
            CubePrefab = _clickCubePrefab
        });
    }

    private void OnDestroy()
    {
        _root.Dispose();
    }
}