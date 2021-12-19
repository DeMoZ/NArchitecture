using System;

public class Root : IDisposable
{
    public struct Ctx
    {
        public UIGameState UiPrefab;
        public ClickCube CubePrefab;
        public ClickCatcher ClickCatcher;
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
            UiPrefab = _ctx.UiPrefab,
            CubePrefab = _ctx.CubePrefab,
            ClickCatcher = _ctx.ClickCatcher,
        };

       _rootEntity = new RootEntity(rootEntityCtx);
    }

    public void Dispose()
    {
        _rootEntity.Dispose();
    }
}