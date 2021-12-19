using System;
using UniRx;

public class UiEntity : IDisposable
{
    public struct Ctx
    {
        public IReactiveProperty<bool> OnStart;
        public IReactiveProperty<int> CubeClickedTimes;
    }

    private Ctx _ctx;
    
    public UiEntity(Ctx ctx)
    {
        _ctx = ctx;
    }
    public void Dispose()
    {
        
    }
}