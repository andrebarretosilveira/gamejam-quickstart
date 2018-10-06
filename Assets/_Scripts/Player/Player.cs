using System.Collections;
using System.Collections.Generic;
using Euchromata.Core.Variables;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BoolVariable CanPlay;
    public FloatVariable MyScore;
    [Space]
    public PoolObject[] circlesPoolObjs;
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
            int rnd = Random.Range(0, circlesPoolObjs.Length);
            GameObject circle = GameManager.PoolManager.GetInstance(circlesPoolObjs[rnd]);

            if(circle == null) return;
            
            circle.transform.position = position;
            circle.SetActive(true);

            GameManager.SoundManager.PlaySfx(ClickSfx);

            MyScore.ApplyChange(+10);
        }
    }
}
