using Pixelplacement;
using UnityEngine;

[DisallowMultipleComponent]
public class TweenFieldOfView : TweenComponentStandard<Camera, float>
{  
    public override void PlayTween()
    {
        var startValue = startIsCurrent ?
            target.fieldOfView : this.startValue;

        var endValue = endIsOffset ?
            target.fieldOfView + this.endValue : this.endValue;

        var animationCurve = TweenAnimation.GetCorrespondingAnimationCurve(this.animationCurve);

        Tween.FieldOfView(
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
