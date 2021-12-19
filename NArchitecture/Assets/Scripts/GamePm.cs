using System;

public class GamePm : IDisposable
{
    public struct Ctx
    {
        public ReactiveEvent<bool> OnCubeClick;
    }

    private Ctx _ctx;
    
    public GamePm(Ctx ctx)
    {
        _ctx = ctx;
    }
    
    public void Dispose()
    {
        
    }
}