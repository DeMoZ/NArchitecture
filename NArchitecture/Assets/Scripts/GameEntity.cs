using System;
using UniRx;

public class GameEntity : IDisposable
{
    public struct Ctx
    {
        public ClickCubeView CubePrefab;
        public GameCamera Camera;
        public ClickCatcher ClickCatcher;
        public UIGameStateView UiView;

        public IReactiveProperty<bool> OnStart;
        public IReactiveProperty<int> LevelIndex;
        public ReactiveEvent<bool> OnAnyClick;
        public ReactiveEvent<bool> OnObjectHit;
        public IReactiveProperty<int> AnyClickCount;
        public IReactiveProperty<int> CubeClickCount;
    }

    private Ctx _ctx;
    private GamePm _gamePm;
    private PlayerInput _playerInput;
    public GameEntity(Ctx ctx)
    {
        _ctx = ctx;

        CreatePlayerInput();

        var gamePmCtx = new GamePm.Ctx
        {
            CubePrefab = _ctx.CubePrefab,
            OnAnyClick = _ctx.OnAnyClick,
            OnObjectHit = _ctx.OnObjectHit,
            AnyClickCount = _ctx.AnyClickCount,
            CubeClickCount = _ctx.CubeClickCount
        };

        _gamePm = new GamePm(gamePmCtx);

        //_ctx.OnStart.Subscribe(a => LevelStarted(_ctx.LevelIndex.Value));

    }

    

    private void CreatePlayerInput()
    {
        ReactiveEvent<float, float> onInputClick = new ReactiveEvent<float, float>();
        onInputClick = new ReactiveEvent<float, float>();

       
        var clickCatcherCtx = new ClickCatcher.Ctx
        {
            OnAnyClick = _ctx.OnAnyClick,
            OnInputClick = onInputClick
        };

        _ctx.ClickCatcher.SetCtx(clickCatcherCtx);

        PlayerInput.Ctx playerInputCtx = new PlayerInput.Ctx
        {
            OnInputClick = onInputClick,
            Camera = _ctx.Camera.Camera ,
            OnObjectHit = _ctx.OnObjectHit
        };

        _playerInput = new PlayerInput(playerInputCtx);
    }

    public void Dispose()
    {
    }
}