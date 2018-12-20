using Euchromata.Core.Variables;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BoolVariable CanPlay;
    public FloatVariable MyScore;
    [Space]
    public PoolObject[] CirclesPoolObjs;
    [Space]
    public int ScorePerClick;
    [Space]
    public AudioClip ClickSfx;

    private void Update()
    {
        if(!CanPlay.Value) return;

        // Increse score by time
        MyScore.ApplyChange(Time.deltaTime * 3);

        // On Click
        if(Input.GetButtonUp("Fire1"))
        {
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position = new Vector3(position.x, position.y, 0);

            // var circle = CircleToSpawn.GetInstance();
            int rnd = Random.Range(0, CirclesPoolObjs.Length);
            GameObject circle = PoolManager.Instance.GetClone(CirclesPoolObjs[rnd]);

            if(circle == null) return;
            
            circle.transform.position = position;
            circle.SetActive(true);

            SoundManager.Instance.PlaySfx(ClickSfx);

            MyScore.ApplyChange(+ScorePerClick);
        }
    }
}
