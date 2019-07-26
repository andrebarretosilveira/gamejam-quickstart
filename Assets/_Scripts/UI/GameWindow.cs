using System.Collections;
using UnityEngine;
using Pixelplacement;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class GameWindow : MonoBehaviour
{
    [Header("Open/Close Animations")]
    public float animationDuration = 1;
    public float animationDelay = 0;

    [Header("Scale")]
    public bool animateScale = true;
    [ConditionalHide("animateScale")]
    public Vector3 scaleFrom = Vector3.zero;
    [ConditionalHide("animateScale")]
    public Vector3 scaleTo = Vector3.one;
    [ConditionalHide("animateScale")]
    public TweenAnimations.TweenAnimationCurve scaleCurve;

    [Header("Transparency")]
    public bool animateTransparency = true;
    [ConditionalHide("animateTransparency")]
    public float alfaFrom = 0;
    [ConditionalHide("animateTransparency")]
    public float alfaTo = 1;
    [ConditionalHide("animateTransparency")]
    public TweenAnimations.TweenAnimationCurve transparencyCurve;

    [Header("Movement")]
    public bool animateMovement;
    [ConditionalHide("animateMovement")]
    public bool useAnchoredPosition = false;
    [ConditionalHide("animateMovement")]
    public Vector3 moveFrom;
    [ConditionalHide("animateMovement")]
    public Vector3 moveTo;
    [ConditionalHide("animateMovement")]
    public TweenAnimations.TweenAnimationCurve movementCurve;

    [Header("Close Window Automatically?")]
    public bool closeOnAwake = false;
    [ConditionalHide("closeOnAwake")]
    public float closeOnAwakeDelay;
    [Space]
    public bool closeOnOpen = false;
    [ConditionalHide("closeOnOpen")]
    public float closeOnOpenDelay;

    [Header("Open/Close Events")]
    [Space]
    public UnityEvent onWindowOpeningBegin;
    [Space]
    public UnityEvent onWindowOpened;
    [Space]
    public UnityEvent onWindowClosingBegin;
    [Space]
    public UnityEvent onWindowClosed;

    [Header("Window Status")]
    public bool isWindowOpen;

    [Header("Other")]
    public bool startHidden;

    private void Awake()
    {
        if(closeOnAwake)
            StartCoroutine(WaitAndThen(closeOnAwakeDelay, CloseWindow));

        if (startHidden)
            HideWindow();
    }

    private void OnDisable()
    {
        isWindowOpen = false;
    }

    public void OpenThenClose(float seconds)
    {
        StartCoroutine(WaitAndThen(seconds, CloseWindow));

        OpenWindow();
    }

    public void OpenWindow()
    {
        if (isWindowOpen) return;

        this.gameObject.SetActive(true);

        isWindowOpen = true;

        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        DoOpeningTweens();

        StartCoroutine(WaitAndThen(animationDuration, onWindowOpened.Invoke));

        if (closeOnOpen)
        {
            StartCoroutine(WaitAndThen(closeOnOpenDelay, CloseWindow));
        }
    }

    public void CloseWindow()
    {
        if (!isWindowOpen) return;

        DoClosingTweens();

        StartCoroutine(WaitAndThen(animationDuration, onWindowClosed.Invoke));

        StartCoroutine(WaitAndThen(animationDuration, HideWindow));
    }

    public void ToggleWindow()
    {
        if (isWindowOpen) CloseWindow();
        else OpenWindow();
    }

    private void DoOpeningTweens()
    {
        CancelWindowTweens();

        if (animateScale)
        {
            Tween.LocalScale(this.transform, scaleFrom, scaleTo,
                animationDuration, animationDelay,
                TweenAnimations.GetCorrespondingAnimationCurve(scaleCurve));
        }
        

        if(animateTransparency)
        {
            Tween.CanvasGroupAlpha(GetComponent<CanvasGroup>(), alfaFrom, alfaTo,
                animationDuration, animationDelay,
                TweenAnimations.GetCorrespondingAnimationCurve(transparencyCurve));
        }
        

        if(animateMovement)
        {
            if (useAnchoredPosition)
                Tween.AnchoredPosition(this.transform as RectTransform, moveFrom, moveTo,
                animationDuration, animationDelay,
                TweenAnimations.GetCorrespondingAnimationCurve(movementCurve));
            else
                Tween.LocalPosition(this.transform, moveFrom, moveTo,
                animationDuration, animationDelay,
                TweenAnimations.GetCorrespondingAnimationCurve(movementCurve));
        }
    }

    private void DoClosingTweens()
    {
        CancelWindowTweens();

        if (animateScale)
        {
            Tween.LocalScale(this.transform, scaleFrom,
                animationDuration, animationDelay,
                TweenAnimations.GetCorrespondingAnimationCurve(scaleCurve));
        }
            

        if(animateTransparency)
        {
            Tween.CanvasGroupAlpha(GetComponent<CanvasGroup>(), alfaFrom,
                animationDuration, animationDelay,
                TweenAnimations.GetCorrespondingAnimationCurve(transparencyCurve));
        }
            

        if (animateMovement)
        {
            if(useAnchoredPosition)
                Tween.AnchoredPosition(this.transform as RectTransform, moveFrom,
                animationDuration, animationDelay,
                TweenAnimations.GetCorrespondingAnimationCurve(movementCurve));
            else
                Tween.LocalPosition(this.transform, moveFrom,
                animationDuration, animationDelay,
                TweenAnimations.GetCorrespondingAnimationCurve(movementCurve));
        }


    }

    public void ShowWindow()
    {
        isWindowOpen = true;

        CancelWindowTweens();

        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void HideWindow()
    {
        isWindowOpen = false;

        CancelWindowTweens();

        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    private void CancelWindowTweens()
    {
        Tween.Cancel(this.transform.GetInstanceID());
        Tween.Cancel(this.transform.GetInstanceID());
        Tween.Cancel(this.transform.GetInstanceID());
    }

    private IEnumerator WaitAndThen(float waitSeconds, System.Action callback)
    {
        yield return new WaitForSeconds(waitSeconds);

        callback.Invoke();
    }
}
