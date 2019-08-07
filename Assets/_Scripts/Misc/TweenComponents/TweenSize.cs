using Pixelplacement;
using UnityEngine;

[DisallowMultipleComponent]
public class TweenSize : TweenComponentStandard<RectTransform, Vector2>
{  
    public override void PlayTween()
    {
        var startValue = startIsCurrent ?
            target.rect.size : this.startValue;

        var endValue = endIsOffset ?
            target.rect.size + this.endValue : this.endValue;

        var animationCurve = TweenAnimation.GetCorrespondingAnimationCurve(this.animationCurve);

        Tween.Size(
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
