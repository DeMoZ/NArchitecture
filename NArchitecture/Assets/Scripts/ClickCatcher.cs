using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCatcher : MonoBehaviour, IPointerClickHandler
{
    public struct Ctx
    {
        public ReactiveEvent<bool> OnAnyClick ;
        public ReactiveEvent<float, float> OnInputClick ;
    }

    private Ctx _ctx;

    public void SetCtx(Ctx ctx)
    {
        _ctx = ctx;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var position = eventData.position;
        _ctx.OnInputClick.Notify(position.x, position.y);
        _ctx.OnAnyClick.Notify(true);
    }
}