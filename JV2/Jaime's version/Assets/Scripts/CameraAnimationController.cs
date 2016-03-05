using UnityEngine;
using System.Collections;

public class CameraAnimationController : MonoBehaviour {

    public Animator CameraAnimator;
    public int currentPanel = 0;
	// Use this for initialization
	void Start () {
        Animator CameraAnimator = GetComponent<Animator>() as Animator;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentPanel == 0)
        {
            moveToPanelOne();
           // currentPanel += 1;
        }
        if (currentPanel == 1)
            moveToPanelTwo();
        if (currentPanel == 2)
            moveToPanelThree();
        if (currentPanel == 3)
            moveToPanelFour();
        if (currentPanel == 4)
            moveToPanelFive();
        if (currentPanel == 5)
            moveToPanelSix();
        if (currentPanel == 6)
            moveToEndScene();
        if (currentPanel == 7)
            GoToNextLevel("");

	}

    public void moveToPanelOne()
    {
        if (Input.anyKeyDown)
        {
            CameraAnimator.SetTrigger("WindowOne");
            currentPanel = 1;
            Debug.Log("I have been asked to move position");
        }
    }

    public void moveToPanelTwo()
    {
        if (Input.anyKeyDown)
        {
            CameraAnimator.SetTrigger("WindowTwo");
            currentPanel = 2;
            Debug.Log("I have been asked to move position");
        }
    }

    public void moveToPanelThree()
    {
        if (Input.anyKeyDown)
        {
            CameraAnimator.SetTrigger("WindowThree");
            currentPanel += 1;
            Debug.Log("I have been asked to move position");
        }
    }

    public void moveToPanelFour()
    {
        if (Input.anyKeyDown)
        {
            CameraAnimator.SetTrigger("WindowFour");
            currentPanel += 1;
            Debug.Log("I have been asked to move position");
        }
    }

    public void moveToPanelFive()
    {
        if (Input.anyKeyDown)
        {
            CameraAnimator.SetTrigger("WindowFive");
            currentPanel += 1;
            Debug.Log("I have been asked to move position");
        }
    }

    public void moveToPanelSix()
    {
        if (Input.anyKeyDown)
        {
            CameraAnimator.SetTrigger("WindowSix");
            currentPanel += 1;
            Debug.Log("I have been asked to move position");
        }
    }

    public void moveToEndScene()
    {
        if (Input.anyKeyDown)
        {
            CameraAnimator.SetTrigger("EndScene");
            currentPanel += 1;
            Debug.Log("I have been asked to move position");
        }
    }

    public void GoToNextLevel(string SceneName)
    {
        StartCoroutine(GoToNextLevelCo(SceneName));
    }

    private IEnumerator GoToNextLevelCo(string SceneName)
    {
        yield return new WaitForSeconds(1);

        if (string.IsNullOrEmpty(SceneName))
            Debug.Log("meant to load default level");
        else
            Application.LoadLevel(SceneName);
    }
}
