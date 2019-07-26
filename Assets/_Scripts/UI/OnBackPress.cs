using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class OnBackPress : MonoBehaviour
{
    [Space]

    [FormerlySerializedAs("method")]
	public UnityEvent response;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            response.Invoke();
        }
    }

}