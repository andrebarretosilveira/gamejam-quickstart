using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
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
			GameManager.SoundManager.PlaySfx(sfx);
		}
		else if (randomSfx)
		{
			AudioClip randomSfx = sfxs[Random.Range(0, sfxs.Length)];
			GameManager.SoundManager.PlaySfx(randomSfx);
		}
		
	}
}