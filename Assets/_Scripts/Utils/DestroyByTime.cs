using System.Collections;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [Range(0, 10)]
    public float lifetime;
    public bool onlyDeactivate;

    private void OnEnable()
    {
        if(onlyDeactivate)
        {
            StartCoroutine(DeactivateObjectByTime(this.gameObject, lifetime));
        }
        else
        {
            Destroy(this.gameObject, lifetime);
        }
    }

    private IEnumerator DeactivateObjectByTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);

        PoolManager.Instance.ReleaseObject(this.gameObject);
    }

}
