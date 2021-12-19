using System;

public class CubeEntity : IDisposable
{
    public struct Ctx
    {
        
    }

    private Ctx _ctx;
    
    public CubeEntity(Ctx ctx)
    {
        _ctx = ctx;
    }
    public void Dispose()
    {
        
    }
}