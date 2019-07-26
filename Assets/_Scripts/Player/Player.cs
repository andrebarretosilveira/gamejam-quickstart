using Euchromata.Core.Variables;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BoolVariable canPlay;
    public FloatVariable myScore;
    [Space]
    public PoolManager circlesPoolManager;
    public PoolObject[] circlesPoolObjs;
    [Space]
    public int scorePerClick;
    [Space]
    public AudioSource clickAudioSource;
    public AudioClip clickSfx;

    private void Update()
    {
        if(!canPlay.Value) return;

        // Increse score by time
        myScore.ApplyChange(Time.deltaTime * 3);

        // On Click
        if(Input.GetButtonUp("Fire1"))
        {
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position = new Vector3(position.x, position.y, 0);

            // var circle = CircleToSpawn.GetInstance();
            int rnd = Random.Range(0, circlesPoolObjs.Length);
            GameObject circle = circlesPoolManager.GetClone(circlesPoolObjs[rnd]);
            // GameObject circle = null;

            if(circle == null) return;
            
            circle.transform.position = position;
            circle.SetActive(true);

            clickAudioSource.PlayOneShot(clickSfx);

            myScore.ApplyChange(+scorePerClick);
        }
    }
}
