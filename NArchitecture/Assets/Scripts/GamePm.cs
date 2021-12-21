using System;
using UniRx;

public class GamePm : IDisposable
{
    public struct Ctx
    {
        public ClickCubeView CubePrefab;
        public ReactiveEvent<bool> OnAnyClick;
        public ReactiveEvent<bool> OnObjectHit;
        
        public IReactiveProperty<int> AnyClickCount;
        public IReactiveProperty<int> CubeClickCount;
    }

    private Ctx _ctx;
    
    private ReactiveEvent<bool> _onCubeHit;
  

    public GamePm(Ctx ctx)
    {
        _ctx = ctx;

        _onCubeHit = new ReactiveEvent<bool>();

        InstantiateCube();
            
        _ctx.OnAnyClick.Subscribe(OnAnyClick);
        _ctx.OnObjectHit.Subscribe(OnObjectClick);
    }


    private void InstantiateCube()
    {

        CubeEntity.Ctx cubeEntityCtx = new CubeEntity.Ctx
        {
            CubePrefab = _ctx.CubePrefab,
            CubeClickCount = _ctx.CubeClickCount
        };

        CubeEntity cubeEntity = new CubeEntity(cubeEntityCtx);
    }

    private void OnAnyClick(bool isObjectClicked)
    {
        _ctx.AnyClickCount.Value++;
    }

    private void OnObjectClick(bool hitResult)
    {
        if (hitResult)
        {
            _ctx.CubeClickCount.Value++;
            _onCubeHit.Notify(true);
        }
    }

    public void Dispose()
    {
    }
}