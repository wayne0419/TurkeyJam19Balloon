using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
	// denote the game object it refers to
	public GameObject player;
    // denote the text it will refer to
    public Text txt;
    public AudioSource cheers;
    public Animator anim;

	// denote the start position
	private int final_score;
    // Start is called before the first frame update
    void Start()
    {
		final_score = 0;
    }

    // Update is called once per frame
    void Update()
    {
		int score = (int)(player.transform.position.y);
		if (score > final_score)
        {
            final_score = score;
            if (final_score % 100 == 0 && final_score != 0)
            {
                anim.SetTrigger("cheer");
                cheers.Play();
            }
        }

        txt.text = "Score: " + final_score.ToString();
    }
}
