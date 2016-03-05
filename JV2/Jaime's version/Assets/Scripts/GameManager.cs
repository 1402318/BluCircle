using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Reflection;
//using UnityEditor;

public class GameManager : MonoBehaviour
{
    public float sensitivityFactorValue;
    public GameObject[] SeeSaws;

    void Awake()
    {
        //ClearConsole();
    }
	// Use this for initialization
	void Start () {
        Debug.Log("GameManager loaded");
        LoadSensitivityFactor();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadSensitivityFactor()
    {
        sensitivityFactorValue = PlayerPrefs.GetFloat("SensitivityFactor");
        Debug.Log("sensitivty factor value loaded is " + sensitivityFactorValue);
    }

    //public static void ClearConsole()
    //{
    //    var assembly = Assembly.GetAssembly(typeof(UnityEditor.ActiveEditorTracker));
    //    var type = assembly.GetType("UnityEditorInternal.LogEntries");
    //    var method = type.GetMethod("Clear");
    //    method.Invoke(new object(), null);
    //}

}
