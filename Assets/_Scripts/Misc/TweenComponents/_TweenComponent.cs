using UnityEngine;
using Pixelplacement;
using UnityEngine.Events;

public abstract class TweenComponentBase<T> : MonoBehaviour
{
    [Header("General")]
    public T target;
    [Space]
    public bool obeyTimeScale = true;
    public bool playOnAwake = false;
    [Space]
    public float duration;
    public float delay;
    [Space]
    public TweenAnimation.Curve animationCurve;
    public Tween.LoopType loopType;

    [Header("Event Responses")]
    public UnityEvent onTweenBegin;
    public UnityEvent onTweenEnd;


    protected void OnEnable()
    {
        if (playOnAwake)
        {
            PlayTween();
        }
    }

    protected void OnDisable()
    {
        StopTween();
    }

    public abstract void PlayTween();

    public void StopTween()
    {
        Tween.Stop(TargetInstanceID);
    }

    public void CancelTween()
    {
        Tween.Cancel(TargetInstanceID);
    }

    public void FinishTween()
    {
        Tween.Finish(TargetInstanceID);
    }

    public int TargetInstanceID
    {
        get { return (target as Object).GetInstanceID(); }
    }

}

public abstract class TweenComponentStandard<T, V> : TweenComponentBase<T>
{
    [Header("Specific Tween Config")]
    public bool startIsCurrent;
    public bool endIsOffset;
    [Space]
    [ConditionalHide("startIsCurrent", false, true)]
    public V startValue;
    public V endValue;
}

public static class TweenAnimation
{
    public enum Curve
    {
        None,
        EaseIn,
        EaseInStrong,
        EaseOut,
        EaseOutStrong,
        EaseInOut,
        EaseInOutStrong,
        EaseInBack,
        EaseOutBack,
        EaseInOutBack,
        EaseSpring,
        EaseBounce,
        EaseWobble,
    }

    public static AnimationCurve GetCorrespondingAnimationCurve(Curve tweenCurve)
    {
        switch (tweenCurve)
        {
            case Curve.None:
                return null;

            case Curve.EaseIn:
                return Tween.EaseIn;

            case Curve.EaseInStrong:
                return Tween.EaseInStrong;

            case Curve.EaseOut:
                return Tween.EaseOut;

            case Curve.EaseOutStrong:
                return Tween.EaseOutStrong;

            case Curve.EaseInOut:
                return Tween.EaseInOut;

            case Curve.EaseInOutStrong:
                return Tween.EaseInOutStrong;

            case Curve.EaseInBack:
                return Tween.EaseInBack;

            case Curve.EaseOutBack:
                return Tween.EaseOutBack;

            case Curve.EaseInOutBack:
                return Tween.EaseInOutBack;

            case Curve.EaseSpring:
                return Tween.EaseSpring;

            case Curve.EaseBounce:
                return Tween.EaseBounce;

            case Curve.EaseWobble:
                return Tween.EaseWobble;

            default:
                Debug.LogError("Tween Animation Curve not found.");
                return null;
        }
    }
}

