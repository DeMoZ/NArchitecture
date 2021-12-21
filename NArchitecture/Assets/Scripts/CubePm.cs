using UniRx;
using UnityEngine;

public class CubePm
{
    public struct Ctx
    {
        public ClickCubeView CubeView;
        public IReactiveProperty<int> CubeClickCount;
    }

    private Ctx _ctx;
    public CubePm(Ctx ctx)
    {
        _ctx = ctx;
        
        _ctx.CubeView.transform.position = Vector3.one;
        _ctx.CubeClickCount.Subscribe((_) => _ctx.CubeView.OnClick());
    }
}