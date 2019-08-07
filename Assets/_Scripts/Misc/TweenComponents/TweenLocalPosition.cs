using Pixelplacement;
using UnityEngine;

[DisallowMultipleComponent]
public class TweenLocalPosition : TweenComponentStandard<Transform, Vector3>
{     
    public override void PlayTween()
    {
        var startValue = startIsCurrent ?
            target.transform.localPosition : this.startValue;

        var endValue = endIsOffset ?
            target.transform.localPosition + this.endValue : this.endValue;

        var animationCurve = TweenAnimation.GetCorrespondingAnimationCurve(this.animationCurve);

        Tween.LocalPosition(
            target.transform,
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
