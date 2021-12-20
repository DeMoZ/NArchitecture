using UnityEngine;

public class EnterPoint : MonoBehaviour
{
    [SerializeField] private GamePrefabs _gamePrefabs = default;
    [SerializeField] private GameCamera _camera = default;
    
    private Root _root;

    private void Start()
    {
        _root = new Root(new Root.Ctx
        {
            GamePrefabs = _gamePrefabs,
            Camera = _camera,
        });
    }

    private void OnDestroy()
    {
        _root.Dispose();
    }
}