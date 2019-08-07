using Pixelplacement;
using UnityEngine;

[DisallowMultipleComponent]
public class TweenLocalRotation : TweenComponentStandard<Transform, Vector3>
{     
    public override void PlayTween()
    {
        var startValue = startIsCurrent ?
            target.transform.localRotation.eulerAngles : this.startValue;

        var endValue = endIsOffset ?
            target.transform.localRotation.eulerAngles + this.endValue : this.endValue;

        var animationCurve = TweenAnimation.GetCorrespondingAnimationCurve(this.animationCurve);

        Tween.LocalRotation(
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
