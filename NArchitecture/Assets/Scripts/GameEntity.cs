using System;
using UniRx;

public class GameEntity : IDisposable
{
    public struct Ctx
    {
        public readonly ReactiveEvent<bool> OnStart;
        public readonly IReactiveProperty<int> LevelIndex;
        public readonly ReactiveEvent<bool> OnCubeClick;
    }

    private Ctx _ctx;
    private GamePm _gamePm;

    public GameEntity(Ctx ctx)
    {
        _ctx = ctx;

        CreatePlayerInput();
        
        var gamePmCtx = new GamePm.Ctx
        {
            OnCubeClick = _ctx.OnCubeClick
        };
        
        var gamePm = new GamePm(gamePmCtx);

        _ctx.OnStart.Subscribe(a => LevelStarted(_ctx.LevelIndex.Value));

    }

    private void CreatePlayerInput()
    {
        ReactiveEvent<float, float> onInputClick = new ReactiveEvent<float , float>();
        ReactiveEvent<bool> onCubeClicked = new ReactiveEvent<bool>();
        
        var clickCatcherCtx = new ClickCatcher.Ctx
        {
            OnInputClick = onInputClick
        };
        
        /*_ctx.ClickCatcher.SetCtx(swipeCatcherCtx);

        PlayerInput.Ctx playerInputCtx = new PlayerInput.Ctx
        {
            gameState = _ctx.state,
            onInputDirection = onInputDirection,
            playerDirection = _playerMoveDirection,
            isPlayerMoving = _isPlayerMoving,
        };

        _playerInput = new PlayerInput(playerInputCtx);*/
    }

    private void LevelStarted(int ctxLevelIndex)
    {
//_gamePm.Ctx    
    }

    public void Dispose()
    {
        
    }
}