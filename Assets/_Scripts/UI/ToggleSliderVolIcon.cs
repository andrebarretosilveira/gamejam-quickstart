using UnityEngine;
using UnityEngine.UI;
using Euchromata.Core.Variables;
using UnityEngine.Serialization;

[RequireComponent(typeof(Slider))]
public class ToggleSliderVolIcon : MonoBehaviour
{
    public MixerGroupSetting audioSetting;
    [Space]
    [FormerlySerializedAs("SliderInfoImg")]
    public Image sliderInfoImg;
    [FormerlySerializedAs("VolOnSprite")]
    public Sprite volOnSprite;
    [FormerlySerializedAs("VolOffSprite")]
    public Sprite volOffSprite;

    private Slider slider;


    private void Awake()
    {
        slider = this.gameObject.GetComponent<Slider>();
    }

    private void Start()
	{
        slider.value = audioSetting.Volume;

        UpdateSliderImg();
    }

    public void UpdateSliderImg()
    {      
        if (slider.value < 0.01f)
        {
            sliderInfoImg.sprite = volOffSprite;
        }
        else
        {
            sliderInfoImg.sprite = volOnSprite;
        }
    }
}