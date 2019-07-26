using Euchromata.Core.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class MessageTextUpdater : MonoBehaviour
{
    [FormerlySerializedAs("PlayerScore")]
    public FloatVariable playerScore;
    [FormerlySerializedAs("MessageText")]
    public TextMeshProUGUI messageText;

	// Use this for initialization
	void Start ()
	{
		ResetText();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerScore.Value > 5)
        {
            messageText.text = "Yay I'm winning!";
        }

        if(playerScore.Value > 50)
        {
            messageText.text = "This game is super easy...";
        }

        if (playerScore.Value > 100)
        {
            messageText.text = "zzz";
        }

        if (playerScore.Value > 200)
        {
            messageText.text = "It seems you like idle games, huh";
        }

		if (playerScore.Value > 300)
        {
            messageText.text = "Well, press on, my friend.";
        }

		if (playerScore.Value > 350)
        {
            messageText.text = "";
        }
	}

	public void ResetText()
	{
		messageText.gameObject.SetActive(true);
		messageText.text = "";
	}
}
