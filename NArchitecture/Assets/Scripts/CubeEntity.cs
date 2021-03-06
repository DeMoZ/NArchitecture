using System;
using UniRx;
using Object = UnityEngine.Object;
public class CubeEntity : IDisposable
{
    public struct Ctx
    {
        public ClickCubeView CubePrefab;
        public IReactiveProperty<int> CubeClickCount;
    }

    private Ctx _ctx;
    
    public CubeEntity(Ctx ctx)
    {
        _ctx = ctx;

        ClickCubeView.Ctx clickCubeViewCtx = new ClickCubeView.Ctx() { };
        ClickCubeView cubeView = Object.Instantiate(_ctx.CubePrefab);

        cubeView.SetCtx(clickCubeViewCtx);

        CubePm.Ctx cubePmCtx = new CubePm.Ctx
        {
            CubeView = cubeView,
            CubeClickCount = _ctx.CubeClickCount
        };

        CubePm cubePm = new CubePm(cubePmCtx);
        
    }
    public void Dispose()
    {
        
    }
}