using UnityEngine;
using System.Collections;

public class Debugger : MonoBehaviour 
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DisplayMessage()
    {
        Debug.Log("This " + gameObject.name + " " + "is working");
    }
    /**  Used on gameObjects to test if they are interactale**/

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
