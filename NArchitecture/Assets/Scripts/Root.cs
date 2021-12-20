using System;

public class Root : IDisposable
{
    public struct Ctx
    {
        public GamePrefabs GamePrefabs;
        public GameCamera Camera;
    }

    private Ctx _ctx;
    private RootEntity _rootEntity;

    public Root(Ctx ctx)
    {
        _ctx = ctx;
        CreateRootEntity();
    }

    private void CreateRootEntity()
    {
        var rootEntityCtx = new RootEntity.Ctx
        {
            GamePrefabs = _ctx.GamePrefabs,
            Camera = _ctx.Camera
        };

       _rootEntity = new RootEntity(rootEntityCtx);
    }

    public void Dispose()
    {
        _rootEntity.Dispose();
    }
}