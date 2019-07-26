using Euchromata.Core.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreTextUpdater : MonoBehaviour
{
    [FormerlySerializedAs("Text")]
    public TextMeshProUGUI text;
    [FormerlySerializedAs("Variable")]
    public FloatVariable variable;


    private void OnEnable()
    {
        text.text = Mathf.Floor(variable.Value).ToString();
    }

    private void Update()
    {
        text.text = Mathf.Floor(variable.Value).ToString();
    }
}