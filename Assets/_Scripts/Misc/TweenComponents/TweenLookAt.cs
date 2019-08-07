using Pixelplacement;
using UnityEngine;

[DisallowMultipleComponent]
public class TweenLookAt : TweenComponentBase<Transform>
{  
    [Header("Specific Tween Config")]
    public Transform targetToLookAt;
    public Vector3 up;

    public override void PlayTween()
    {
        var animationCurve = TweenAnimation.GetCorrespondingAnimationCurve(this.animationCurve);

        Tween.LookAt(
            target.transform,
            targetToLookAt,
            up,
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
