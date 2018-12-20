using UnityEngine;
using UnityEngine.Events;

public class OnBackPress : MonoBehaviour
{
    [Space]

	public UnityEvent method;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            method.Invoke();
        }
    }

}