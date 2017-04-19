using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WhackAMole : MonoBehaviour
{


    public GameObject molePrefab;
    // public List<GameObject> moles = new List<GameObject>();
    public int dimension = 3;
    public int curScore = 0;
    public float gameLength = 30;
    private float gameTimer;
	public Text timerText;
	public Text scoreText;

    void Start()
    {
		float offset = - dimension/1.5f + 0.0f;
        // instantiate all of the moles
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                GameObject m = Instantiate(molePrefab);
                m.transform.SetParent(transform);
                m.transform.position = new Vector3(j*2 + offset,i*2 + offset, 0);
                //m.GetComponent<EventTrigger>().triggers[0].callback.AddListener((data)=>MoleTapped(i*dimension+j));
				m.GetComponent<Mole>().moleManager = this; 
                // moles.Add(m);
            }
        }
		gameTimer = gameLength;
		timerText.text = "Timer:"+((int)(gameTimer*100f)/100f) + "s";
		curScore = 0;
		scoreText.text = "Score: "+curScore;
    }

    void Update()
    {
        if (gameTimer >= 0)
        {
            gameTimer-=Time.deltaTime;
			timerText.text = "Timer:"+((int)(gameTimer*100f)/100f) + "s";
        }
        else
        {
            GameOver();
        }
    }
	public void MoleHit() {
		curScore += 1;
		scoreText.text = "Score: "+curScore;
	}
    public void GameOver()
    {
		Debug.Log("Gameover");
		gameTimer = gameLength;
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().FinishGame(curScore);
    }
}
