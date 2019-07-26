using UnityEngine;
using Pixelplacement;

public class TweenAnimations : MonoBehaviour
{
    public enum TweenAnimationCurve
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

    public static AnimationCurve GetCorrespondingAnimationCurve(TweenAnimationCurve tweenCurve)
    {
        switch (tweenCurve)
        {
            case TweenAnimationCurve.None:
                return null;

            case TweenAnimationCurve.EaseIn:
                return Tween.EaseIn;

            case TweenAnimationCurve.EaseInStrong:
                return Tween.EaseInStrong;

            case TweenAnimationCurve.EaseOut:
                return Tween.EaseOut;

            case TweenAnimationCurve.EaseOutStrong:
                return Tween.EaseOutStrong;

            case TweenAnimationCurve.EaseInOut:
                return Tween.EaseInOut;

            case TweenAnimationCurve.EaseInOutStrong:
                return Tween.EaseInOutStrong;

            case TweenAnimationCurve.EaseInBack:
                return Tween.EaseInBack;

            case TweenAnimationCurve.EaseOutBack:
                return Tween.EaseOutBack;

            case TweenAnimationCurve.EaseInOutBack:
                return Tween.EaseInOutBack;

            case TweenAnimationCurve.EaseSpring:
                return Tween.EaseSpring;

            case TweenAnimationCurve.EaseBounce:
                return Tween.EaseBounce;

            case TweenAnimationCurve.EaseWobble:
                return Tween.EaseWobble;

            default:
                Debug.LogError("Tween Animation Curve not found.");
                return null;
        }
    }
}