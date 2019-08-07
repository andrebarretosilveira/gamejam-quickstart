using Pixelplacement;
using UnityEngine;

[DisallowMultipleComponent]
public class TweenRotation : TweenComponentStandard<Transform, Vector3>
{      
    public override void PlayTween()
    {
        var startValue = startIsCurrent ?
            target.transform.rotation.eulerAngles : this.startValue;

        var endValue = endIsOffset ?
            target.transform.rotation.eulerAngles + this.endValue : this.endValue;

        var animationCurve = TweenAnimation.GetCorrespondingAnimationCurve(this.animationCurve);

        Tween.Rotation(
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
