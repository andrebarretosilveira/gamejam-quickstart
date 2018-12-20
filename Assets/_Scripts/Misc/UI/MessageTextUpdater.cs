using Euchromata.Core.Variables;
using TMPro;
using UnityEngine;

public class MessageTextUpdater : MonoBehaviour
{
    public FloatVariable PlayerScore;
    public TextMeshProUGUI MessageText;

	// Use this for initialization
	void Start ()
	{
		ResetText();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerScore.Value > 5)
        {
            MessageText.text = "Yay I'm winning!";
        }

        if(PlayerScore.Value > 50)
        {
            MessageText.text = "This game is super easy...";
        }

        if (PlayerScore.Value > 100)
        {
            MessageText.text = "zzz";
        }

        if (PlayerScore.Value > 200)
        {
            MessageText.text = "It seems you like idle games, huh";
        }

		if (PlayerScore.Value > 300)
        {
            MessageText.text = "Well, press on, my friend.";
        }

		if (PlayerScore.Value > 350)
        {
            MessageText.text = "";
        }
	}

	public void ResetText()
	{
		MessageText.gameObject.SetActive(true);
		MessageText.text = "";
	}
}
