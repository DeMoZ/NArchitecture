using System;
using UniRx;
using Object = UnityEngine.Object;

/// <summary>
/// Here we go with all of our UniRx fields and UniRx properties
/// </summary>
public class RootEntity : IDisposable
{
    public struct Ctx
    {
        public GamePrefabs GamePrefabs;
        public GameCamera Camera;
    }

    private readonly IReactiveProperty<bool> _onStart;
    private readonly ReactiveEvent<bool> _onAnyClick;
    private readonly ReactiveEvent<bool> _onObjectClick;
    private readonly IReactiveProperty<int> _clickedTimes;
    private readonly IReactiveProperty<int> _levelIndex;

    private Ctx _ctx;
    private ClickCatcher _clickCatcher;
    private UIGameStateView _uiView;

    public RootEntity(Ctx ctx)
    {
        _ctx = ctx;

        _onStart = new ReactiveProperty<bool>();
        _onAnyClick = new ReactiveEvent<bool>();
        _onObjectClick = new ReactiveEvent<bool>();
        _clickedTimes = new ReactiveProperty<int>();
        _levelIndex = new ReactiveProperty<int>();

        CreateGameEntity();
    }

    private void CreateGameEntity()
    {
        _clickCatcher = Object.Instantiate(_ctx.GamePrefabs.ClickCatcherPrefab);
        _uiView = Object.Instantiate(_ctx.GamePrefabs.UiGameStatePrefab);


        var gameEntityCtx = new GameEntity.Ctx
        {
            Camera = _ctx.Camera,
            ClickCatcher = _clickCatcher,
            UiView = _uiView,

            OnStart = _onStart,
            LevelIndex = _levelIndex,
            OnAnyClick = _onAnyClick,
            OnObjectHit = _onObjectClick
        };
        
        var gameEntity = new GameEntity(gameEntityCtx);
    }

    public void Dispose()
    {
    }
}