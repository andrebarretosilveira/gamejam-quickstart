using Pixelplacement;
using UnityEngine;

[DisallowMultipleComponent]
public class TweenShake : TweenComponentBase<Transform>
{  
    [Header("Specific Tween Config")]
    public Vector3 initialPosition;
    public Vector3 intensity;

    public override void PlayTween()
    {
        Tween.Shake(
            target.transform,
            initialPosition,
            intensity,
            duration,
            delay,
            loopType,
            onTweenBegin.Invoke,
            onTweenEnd.Invoke,
            obeyTimeScale
        );
    }

}
