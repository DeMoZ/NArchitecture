using UnityEngine;

public class ClickCubeView : MonoBehaviour
{
    public struct Ctx
    {
        
    }

    private Ctx _ctx;

    public void SetCtx(Ctx ctx)
    {
        _ctx = ctx;
    }
    
    public void OnClick()
    {
        Debug.Log($"{this} Clicked on Me");
    }
}