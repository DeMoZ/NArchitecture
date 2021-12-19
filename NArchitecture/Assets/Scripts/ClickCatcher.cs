using UnityEngine;

public class ClickCatcher : MonoBehaviour
{
    public struct Ctx
    {
        public ReactiveEvent<float, float> OnInputClick ;
    }

    private Ctx _ctx;

    public ClickCatcher(Ctx ctx)
    {
        _ctx = ctx;
    }
}