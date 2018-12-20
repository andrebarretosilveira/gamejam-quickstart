using Euchromata.Core.Variables;
using TMPro;
using UnityEngine;

public class ScoreTextUpdater : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public FloatVariable Variable;


    private void OnEnable()
    {
        Text.text = Mathf.Floor(Variable.Value).ToString();
    }

    private void Update()
    {
        Text.text = Mathf.Floor(Variable.Value).ToString();
    }
}