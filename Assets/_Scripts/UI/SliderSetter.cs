using Euchromata.Core.Variables;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SliderSetter : MonoBehaviour
{
    public Slider slider;
    public FloatVariable variable;

    private void Update()
    {
        if (slider != null && variable != null)
            slider.value = variable.Value;
    }
}