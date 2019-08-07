using Pixelplacement;
using UnityEngine;

[DisallowMultipleComponent]
public class TweenVolume : TweenComponentStandard<AudioSource, float>
{  
    public override void PlayTween()
    {
        var startValue = startIsCurrent ?
            target.pitch : this.startValue;

        var endValue = endIsOffset ?
            target.pitch + this.endValue : this.endValue;

        var animationCurve = TweenAnimation.GetCorrespondingAnimationCurve(this.animationCurve);

        Tween.Volume(
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
