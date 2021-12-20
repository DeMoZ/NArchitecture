using System;
using UniRx;
using UnityEngine;

public class GameEntity : IDisposable
{
    public struct Ctx
    {
        public GameCamera Camera;
        public ClickCatcher ClickCatcher;
        public UIGameStateView UiView;

        public IReactiveProperty<bool> OnStart;
        public IReactiveProperty<int> LevelIndex;
        public ReactiveEvent<bool> OnAnyClick;
        public ReactiveEvent<bool> OnObjectHit;
    }

    private Ctx _ctx;
    private GamePm _gamePm;
    private PlayerInput _playerInput;
    private ReactiveEvent<float, float> _onInputClick;
    public GameEntity(Ctx ctx)
    {
        _ctx = ctx;

        CreatePlayerInput();

        var gamePmCtx = new GamePm.Ctx
        {
            OnAnyClick = _ctx.OnAnyClick
        };

        _gamePm = new GamePm(gamePmCtx);

        //_ctx.OnStart.Subscribe(a => LevelStarted(_ctx.LevelIndex.Value));

        _ctx.OnObjectHit.Subscribe(OnClick);
    }

    private void OnClick(bool hitResult)
    {
        Debug.Log($"Object was hit = {hitResult}");
    }

    private void CreatePlayerInput()
    {
        //ReactiveEvent<float, float> onInputClick = new ReactiveEvent<float, float>();
        _onInputClick = new ReactiveEvent<float, float>();

        var clickCatcherCtx = new ClickCatcher.Ctx
        {
            OnInputClick = _onInputClick,
        };

        _ctx.ClickCatcher.SetCtx(clickCatcherCtx);


        PlayerInput.Ctx playerInputCtx = new PlayerInput.Ctx
        {
            OnInputClick = _onInputClick,
            Camera = _ctx.Camera.Camera ,
            OnObjectHit = _ctx.OnObjectHit
        };

        _playerInput = new PlayerInput(playerInputCtx);
    }

    public void Dispose()
    {
    }
}