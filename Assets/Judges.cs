using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judges : MonoBehaviour
{
    public Sprite angryJudges;
    public Sprite happyJudges;
    public Sprite neutralJudges;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = neutralJudges;
    }

    // Update is called once per frame
    void Update()
    {
        if (Rounds.judgesHappy == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = neutralJudges;
        } else if (Rounds.judgesHappy == 1) {
            gameObject.GetComponent<SpriteRenderer>().sprite = happyJudges;
        } else {
            gameObject.GetComponent<SpriteRenderer>().sprite = angryJudges;
        }
    }
}
