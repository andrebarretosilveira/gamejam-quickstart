using UnityEngine;
using UnityEngine.UI;

public class ChangeVolOnSlide : MonoBehaviour
{
    [Space]
    public Image SliderInfoImg;
    public Sprite VolOnSprite;
    public Sprite VolOffSprite;
    [Space]
	public bool ChangeSfxVol;
	public bool ChangeMusicVol;

    private Slider Slider;

    private void Awake()
    {
        Slider = this.gameObject.GetComponent<Slider>();
    }

    private void Start()
	{
        if (Slider == null) return;

		if(ChangeSfxVol)
        {
            Slider.value = SoundManager.Instance.GetSfxVol();
        }
        else if(ChangeMusicVol)
        {
            Slider.value = SoundManager.Instance.GetMusicVol();
        }

        UpdateSliderImg();
    }

	public void OnValueChanged()
	{
		if (Slider == null)
		{
			Debug.LogError("This gameobject ("+this.name+") should have a Slider component.");
			return;
		}

        UpdateSliderImg();

        if (ChangeSfxVol)
        {
            SoundManager.Instance.SetSfxVol(Slider.value);
        }
        else if (ChangeMusicVol)
        {
            SoundManager.Instance.SetMusicVol(Slider.value);
        }
	}

    private void UpdateSliderImg()
    {
        if (Slider.value < 0.01f)
        {
            SliderInfoImg.sprite = VolOffSprite;
        }
        else
        {
            SliderInfoImg.sprite = VolOnSprite;
        }
    }
}