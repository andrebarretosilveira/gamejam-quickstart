using Pixelplacement;
using UnityEngine;

[DisallowMultipleComponent]
public class TweenLocalScale : TweenComponentStandard<Transform, Vector3>
{  
    public override void PlayTween()
    {
        var startValue = startIsCurrent ?
            target.transform.localScale : this.startValue;

        var endValue = endIsOffset ?
            target.transform.localScale + this.endValue : this.endValue;

        var animationCurve = TweenAnimation.GetCorrespondingAnimationCurve(this.animationCurve);

        Tween.LocalScale(
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
