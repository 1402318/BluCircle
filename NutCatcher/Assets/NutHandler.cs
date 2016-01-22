using UnityEngine;
using System.Collections;

public class NutHandler : MonoBehaviour 
{
    public GUIText scoreText;
    private int score;
	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Nut")
        {
            AddScore(1);
            Destroy(other.gameObject);

        } else
        {
            print("didn't add anything");
        }
        if(other)
        {
            print(other.tag);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
