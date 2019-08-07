using Pixelplacement;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class TweenColor : TweenComponentStandard<Graphic, Color>
{
    public override void PlayTween()
    {
        var startValue = startIsCurrent ?
            target.color : this.startValue;

        var endValue = endIsOffset ?
            target.color + this.endValue : this.endValue;

        var animationCurve = TweenAnimation.GetCorrespondingAnimationCurve(this.animationCurve);

        if (target is Image)
        {
            Tween.Color(
                target as Image,
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
        else if(target is RawImage)
        {
            Tween.Color(
                target as RawImage,
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
        else if(target is Text)
        {
            Tween.Color(
                target as Text,
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
        else
        {
            Debug.LogError("Unexpected Graphic type in tween " + this);
        }

    }
}
