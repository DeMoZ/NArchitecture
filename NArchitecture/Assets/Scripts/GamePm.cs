using System;
using UnityEngine;

public class GamePm : IDisposable
{
    public struct Ctx
    {
        public ReactiveEvent<bool> OnAnyClick;
    }

    private Ctx _ctx;
    
    public GamePm(Ctx ctx)
    {
        _ctx = ctx;


        _ctx.OnAnyClick.Subscribe(OnClick);
    }

    private void OnClick(bool isObjectClicked)
    {
        Debug.Log($"GamePm received Onclick. Object Clicked = {isObjectClicked}" );
    }
    
    public void Dispose()
    {
        
    }
}