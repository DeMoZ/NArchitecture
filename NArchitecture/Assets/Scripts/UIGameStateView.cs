using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UIGameStateView : MonoBehaviour
{
    public struct Ctx
    {
        public IReactiveProperty<int> AnyClickCount;
        public IReactiveProperty<int> CubeClickCount;
    }

    private Ctx _ctx;

    [SerializeField] private Text _anyClickCount = default;
    [SerializeField] private Text _cubeClickCount = default;

    public void SetCtx(Ctx ctx)
    {
        _ctx = ctx;

        _ctx.AnyClickCount.Subscribe(AnyClickCount);
        _ctx.CubeClickCount.Subscribe(CubeClickCount);
    }
    private void AnyClickCount(int value)
    {
        _anyClickCount.text = value.ToString();
    }

    private void CubeClickCount(int value)
    {
        _cubeClickCount.text = value.ToString();
    }
}