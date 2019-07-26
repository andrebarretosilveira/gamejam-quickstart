using UnityEngine;
using UnityEngine.Events;

public class OnEnableDisable : MonoBehaviour
{
    [Space]
    public UnityEvent onEnableResponse;
    [Space]
    [Space]
    public UnityEvent onDisableResponse;


    private void OnEnable()
    {
        onEnableResponse.Invoke();
    }

    private void OnDisable()
    {
        onDisableResponse.Invoke();
    }
}
