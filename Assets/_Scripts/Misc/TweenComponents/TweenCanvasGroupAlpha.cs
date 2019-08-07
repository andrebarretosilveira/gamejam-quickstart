using Pixelplacement;
using UnityEngine;

[DisallowMultipleComponent]
public class TweenCanvasGroupAlpha : TweenComponentStandard<CanvasGroup, float>
{    
    public override void PlayTween()
    {
        var startValue = startIsCurrent ?
            target.alpha : this.startValue;

        var endValue = endIsOffset ?
            target.alpha + this.endValue : this.endValue;

        var animationCurve = TweenAnimation.GetCorrespondingAnimationCurve(this.animationCurve);

        Tween.CanvasGroupAlpha(
            target,
            startValue,
            endValue,
            duration,
            delay,
            animationCurve,
            loopType,
            onTweenBegin.Invoke,
            onTweenEnd.Invoke,
            obeyTimeScale
        );
    }
}
