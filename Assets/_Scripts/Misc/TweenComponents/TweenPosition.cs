using Pixelplacement;
using UnityEngine;

[DisallowMultipleComponent]
public class TweenPosition : TweenComponentStandard<Transform, Vector3>
{  
    public override void PlayTween()
    {
        var startValue = startIsCurrent ?
            target.transform.position : this.startValue;

        var endValue = endIsOffset ?
            target.transform.position + this.endValue : this.endValue;

        var animationCurve = TweenAnimation.GetCorrespondingAnimationCurve(this.animationCurve);

        Tween.Position(
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
