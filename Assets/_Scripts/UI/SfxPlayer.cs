using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
	public AudioSource audioSource;

	[Space]

	[ConditionalHide("randomSfx", false, true)]
	public bool singleSfx = true;
	[ConditionalHide("singleSfx", false)]
	public AudioClip sfx;

	[Space]

	[ConditionalHide("singleSfx", false, true)]
	public bool randomSfx;
	[ConditionalHide("randomSfx", false)]
	public AudioClip[] sfxs;

	public void Play()
	{
		if(singleSfx)
		{
			audioSource.PlayOneShot(sfx);
		}
		else if (randomSfx)
		{
			AudioClip randomSfx = sfxs[Random.Range(0, sfxs.Length)];
			audioSource.PlayOneShot(randomSfx);
		}
		
	}
}