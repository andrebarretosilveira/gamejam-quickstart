using Pixelplacement;
using UnityEngine;

[DisallowMultipleComponent]
public class TweenPanStereo : TweenComponentStandard<AudioSource, float>
{
    public override void PlayTween()
    {
        var startValue = startIsCurrent ?
            target.pitch : this.startValue;

        var endValue = endIsOffset ?
            target.pitch + this.endValue : this.endValue;

        var animationCurve = TweenAnimation.GetCorrespondingAnimationCurve(this.animationCurve);

        Tween.PanStereo(
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

    public override string ToString()
    {
        return base.ToString();
    }
}
