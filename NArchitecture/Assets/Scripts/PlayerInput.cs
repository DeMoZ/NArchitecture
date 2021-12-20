using UnityEngine;

public class PlayerInput
{
    public struct Ctx
    {
        public ReactiveEvent<float, float> OnInputClick;
        public Camera Camera;
        public ReactiveEvent<bool> OnObjectHit;
    }

    private readonly Ctx _ctx;

    public PlayerInput(Ctx ctx)
    {
        _ctx = ctx;

        _ctx.OnInputClick.Subscribe(CheckClick);
    }

    private void CheckClick(float x, float y)
    {
        var ray = _ctx.Camera.ScreenPointToRay(new Vector3(x, y));
        _ctx.OnObjectHit.Notify(Physics.Raycast(ray, out var hit));
    }
}