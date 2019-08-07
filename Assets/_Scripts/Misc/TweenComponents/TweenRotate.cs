using Pixelplacement;
using UnityEngine;

[DisallowMultipleComponent]
public class TweenRotate : TweenComponentBase<Transform>
{  
    [Header("Specific Tween Config")]
    public Vector3 amount;
    public Space space;

    public override void PlayTween()
    {
        var animationCurve = TweenAnimation.GetCorrespondingAnimationCurve(this.animationCurve);

        Tween.Rotate(
            target.transform,
            amount,
            space,
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
