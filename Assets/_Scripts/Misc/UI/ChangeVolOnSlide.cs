using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolOnSlide : MonoBehaviour
{
	public bool ChangeSfxVol;
	public bool ChangeMusicVol;

	private void Start()
	{

		OnValueChanged();
	}

	public void OnValueChanged()
	{
		var slider = this.gameObject.GetComponent<Slider>();

		if (slider == null)
		{
			Debug.LogError("This gameobject ("+this.name+") should have a Slider component.");
			return;
		}

		if(ChangeSfxVol)
			SoundManagerBase.SoundVolume = slider.value;

		if(ChangeMusicVol)
			SoundManagerBase.MusicVolume = slider.value;
	}
}