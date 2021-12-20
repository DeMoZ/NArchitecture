using UnityEngine;

public class CubePm
{
    public struct Ctx
    {
        public ClickCubeView CubeView;
    }

    private Ctx _ctx;
    public CubePm(Ctx ctx)
    {
        _ctx = ctx;
        
        _ctx.CubeView.transform.position = Vector3.one;
    }
}