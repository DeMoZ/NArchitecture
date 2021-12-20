using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCatcher : MonoBehaviour, IPointerClickHandler
{
    public struct Ctx
    {
        public ReactiveEvent<float, float> OnInputClick ;
    }

    private Ctx _ctx;

    public void SetCtx(Ctx ctx)
    {
        _ctx = ctx;
        Debug.LogWarning($"!!!!! {this} setCtx");
        Debug.LogWarning($"!!!!! {this} setCtx OnInputClick == null {ctx.OnInputClick == null} ");

        ctx.OnInputClick.Subscribe((a, b) => { Debug.Log($"input click {a};{b}"); });
        _ctx.OnInputClick.Subscribe((a, b) => { Debug.Log($"input click {a};{b}"); });
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var position = eventData.position;
        Debug.Log($"click on screen {position}");
        Debug.Log($"event onInputClick == null {_ctx.OnInputClick == null}");
        _ctx.OnInputClick.Notify(position.x, position.y);
    }
}