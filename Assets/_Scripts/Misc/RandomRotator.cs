using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    [Range(0, 5)]
	public float tumble;
    public bool onlySideways;

	private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody> ();
    }

    private void OnEnable()
    {
        if(onlySideways)
        {
            rb.angularVelocity = Vector3.forward * tumble;
        }
        else
        {
            rb.angularVelocity = Random.insideUnitCircle * tumble;
        }
	}
}
