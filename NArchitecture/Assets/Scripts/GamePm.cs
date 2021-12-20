using System;
using UnityEngine;

public class GamePm : IDisposable
{
    public struct Ctx
    {
        public ReactiveEvent<bool> OnAnyClick;
        public ReactiveEvent<bool> OnObjectHit;
    }

    private Ctx _ctx;
    
    public GamePm(Ctx ctx)
    {
        _ctx = ctx;

        _ctx.OnAnyClick.Subscribe(OnAnyClick);
        _ctx.OnObjectHit.Subscribe(OnObjectClick);

    }

    private void OnAnyClick(bool isObjectClicked)
    {
        Debug.Log($"GamePm received OnAnyclick" );
    }
    private void OnObjectClick(bool hitResult)
    {
        Debug.Log($"GamePm received OnObjectClick was hit = {hitResult}");
    }
    
    public void Dispose()
    {
        
    }
}