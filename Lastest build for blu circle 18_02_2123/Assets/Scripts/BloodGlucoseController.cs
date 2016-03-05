using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BloodGlucoseController : MonoBehaviour 
{
    public Image glucoseHighlight;
    public float glucoseMeterNum;
    public Transform position01;
    public Transform position02;
    public Transform position03;
    public Transform position04;
    public Transform position05;
    public Transform position06;
    public Transform position07;
    public Transform position08;
    public Transform position09;
    public Transform position10;


	// Use this for initialization
	void Start () 
    {
        glucoseMeterNum = 5; //set the glucose meter to be neutral.
        if (glucoseHighlight == null)
            Debug.Log("Please add the object glucose highlighter and place it in the inspector");
        if(glucoseMeterNum != 5)
        glucoseHighlight.transform.position = position05.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        GameObject start = GameObject.Find("Player");
        CatMove others = (CatMove)start.GetComponent(typeof(CatMove));
        

	    if(others.healthImpactPos == true)
        {
            increaseGlucoseLevel(2);
            others.healthImpactPos = false;
        }
        if (others.healthImpactNeg == true)
        {
            decreaseGlucoseLevel(3);
            others.healthImpactNeg = false;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
            Debug.Log(glucoseMeterNum);

        updatePosition();
	}

    public void increaseGlucoseLevel(float change)
    {
        if (glucoseMeterNum <= 9)
        {
            Debug.Log("I'm about to Decrease the glucose number");
            glucoseMeterNum = glucoseMeterNum + change;
        }
    }
    //this script should grow into more than just a numerator, with effects like venyetting.

    public void decreaseGlucoseLevel(float change)
    {
        if (glucoseMeterNum >= 2)
        {
            Debug.Log("I'm about to increase the glucose number");
            glucoseMeterNum = glucoseMeterNum - change;
        }
    }

    public void updatePosition()
    {
        if (glucoseMeterNum == 1)
            glucoseHighlight.transform.position = position01.transform.position;
        if (glucoseMeterNum == 2)
            glucoseHighlight.transform.position = position02.transform.position;
        if (glucoseMeterNum == 3)
            glucoseHighlight.transform.position = position03.transform.position;
        if (glucoseMeterNum == 4)
            glucoseHighlight.transform.position = position04.transform.position;
        if (glucoseMeterNum == 5)
            glucoseHighlight.transform.position = position05.transform.position;
        if (glucoseMeterNum == 6)
            glucoseHighlight.transform.position = position06.transform.position;
        if (glucoseMeterNum == 7)
            glucoseHighlight.transform.position = position07.transform.position;
        if (glucoseMeterNum == 8)
            glucoseHighlight.transform.position = position08.transform.position;
        if (glucoseMeterNum == 9)
            glucoseHighlight.transform.position = position09.transform.position;
        if (glucoseMeterNum == 10)
            glucoseHighlight.transform.position = position10.transform.position;
    }
    //this script should grow into more than just a numerator, with effects like venyetting.
}
