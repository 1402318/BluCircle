using UnityEngine;
using System.Collections;

public class Loadscreen : MonoBehaviour {

	public string LvlSwitch;
	public GameObject Screen1;
	public GameObject Screen2;
	public GameObject Screen3;
	public GameObject Screen4;
	public GameObject Screen5;
	public GameObject Screen6;
	public GameObject Screen7;
	public GameObject Screen8;
	public GameObject Screen9;
	public GameObject Screen10;
	public GameObject Progress;

	private int loadProgress = 0;

	bool Sc1 = false;
	bool Sc2 = false;
	bool Sc3 = false;
	bool Sc4 = false;
	bool Sc5 = false;
	bool Sc6 = false;
	bool Sc7 = false;
	bool Sc8 = false;
	bool Sc9 = false;
	//bool Sc10 = false;
	public GameObject[] images;
	// Use this for initialization
	void Start () 
	{
		Screen1.SetActive (false);
		Screen2.SetActive (false);
		Screen3.SetActive (false);
		Screen4.SetActive (false);
		Screen5.SetActive (false);
		Screen6.SetActive (false);
		Screen7.SetActive (false);
		Screen8.SetActive (false);
		Screen9.SetActive (false);
		Screen10.SetActive (false);
		Progress.SetActive (false);
	}

/*	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Finish") {
		}
	}*/
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && Sc1 == false)
		{
			StartCoroutine(DisplayLoadingScreen(LvlSwitch));
			print("Started sequence");

		}
	}

	IEnumerator DisplayLoadingScreen(string Load)
	{
		//	Sc1 = true;
		//Screen1.SetActive (true);
		Progress.SetActive (true);

		Progress.transform.localScale = new Vector3 (loadProgress, Progress.transform.localScale.y, Progress.transform.localScale.z);

		AsyncOperation async = Application.LoadLevelAsync (Load);
		while (!async.isDone) {
			loadProgress = (int)(async.progress * 100);
			Progress.transform.localScale = new Vector3 (loadProgress, Progress.transform.localScale.y, Progress.transform.localScale.z);
			yield return null;
		}
		if (async.isDone) {
			Progress.SetActive(false);
		}
	}
		/*if (Input.GetMouseButtonDown (0) && Sc1 == true) 
		{
			Sc1=false;
			Sc2=true;
			Screen1.SetActive(false);
			Screen2.SetActive (true);
			Progress.SetActive (true);
			//loadProgress +=20;
		}
		else if (Input.GetMouseButtonDown (0) && Sc2 == true) 
		{
			Sc2=false;
			Sc3=true;
			Screen2.SetActive(false);
			Screen3.SetActive (true);
			Progress.SetActive (true);
			//loadProgress +=10;
		}
		else if (Input.GetMouseButtonDown (0) && Sc3 == true) 
		{
			Sc3=false;
			Sc4=true;
			Screen3.SetActive(false);
			Screen4.SetActive (true);
			Progress.SetActive (true);
			//loadProgress +=10;
		}
		else if (Input.GetMouseButtonDown (0) && Sc4 == true) 
		{
			Sc4=false;
			Sc5=true;
			Screen4.SetActive(false);
			Screen5.SetActive(true);
			Progress.SetActive (true);
			//loadProgress +=10;
		}
		else if (Input.GetMouseButtonDown (0) && Sc5 == true) 
		{
			Sc5=false;
			Sc6=true;
			Screen5.SetActive(false);
			Screen6.SetActive (true);
			Progress.SetActive (true);
			//loadProgress +=10;
		}
		else if (Input.GetMouseButtonDown (0) && Sc6 == true) 
		{
			Sc6=false;
			Sc7=true;
			Screen6.SetActive(false);
			Screen7.SetActive (true);
			Progress.SetActive (true);
			//loadProgress +=10;
		}
		else if (Input.GetMouseButtonDown (0) && Sc7 == true) 
		{
			Sc7=false;
			Sc8=true;
			Screen7.SetActive(false);
			Screen8.SetActive (true);
			Progress.SetActive (true);
			//loadProgress +=10;
		}
		else if (Input.GetMouseButtonDown (0) && Sc8 == true) 
		{
			Sc8=false;
			Sc9=true;
			Screen8.SetActive(false);
			Screen9.SetActive (true);
			Progress.SetActive (true);
			//loadProgress +=10;
		}
		else if (Input.GetMouseButtonDown (0) && Sc9 == true) 
		{
			Sc9=false;
			Sc10=true;
			Screen9.SetActive(false);
			Screen10.SetActive (true);
			Progress.SetActive (true);
			//loadProgress +=10;
		}
		else if (Input.GetMouseButtonDown (0) && Sc10 == true && async.isDone) 
		{
			Sc10=false;
			Screen10.SetActive(false);
			Progress.SetActive(false);
			print("Cease");
			//Application.LoadLevel(LvlSwitch);
		}*/
		//yield return null;
		//&& async.isDone
/*		Screen3.SetActive (false);
		Screen4.SetActive (false);
		Screen5.SetActive (false);
		Screen6.SetActive (false);
		Screen7.SetActive (false);
		Screen8.SetActive (false);
		Screen9.SetActive (false);
		Screen10.SetActive (false);*/
}	