using System;
using UniRx;

/// <summary>
/// Here we go with all of our UniRx fields and UniRx properties
/// </summary>
public class RootEntity : IDisposable
{
    public struct Ctx
    {
        public UIGameState UiPrefab;
        public ClickCube CubePrefab;
        public ClickCatcher ClickCatcher;
    }

    private readonly IReactiveProperty<bool> _onStart;
    private readonly ReactiveEvent<bool> _clicked;
    private readonly IReactiveProperty<int> _clickedTimes;

    private Ctx _ctx;
    public RootEntity(Ctx ctx)
    {
        _ctx = ctx;
        
        _onStart = new ReactiveProperty<bool>();
        _clicked = new ReactiveEvent<bool>();
        _clickedTimes = new ReactiveProperty<int>();
        
        CreateGameEntity();
        CreateUIEntity();
    }

    private void CreateUIEntity()
    {
        var uiEntityCtx = new UiEntity.Ctx
        {
            OnStart = _onStart,
            CubeClickedTimes = _clickedTimes
        };
        var uiEntity = new UiEntity(uiEntityCtx);
    }

    private void CreateGameEntity()
    {
        var gameEntityCtx = new GameEntity.Ctx
        {

        };

        var gameEntity = new GameEntity(gameEntityCtx);
    }

    public void Dispose()
    {
        
    }
}