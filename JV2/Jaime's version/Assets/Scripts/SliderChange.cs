using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class SliderChange : MonoBehaviour 
{
    public Slider slider;
    public Text text;
    public string unit;
    public byte decimals = 2;
    public float savedValue;

    void OnEnable()
    {
        slider.onValueChanged.AddListener(ChangeValue);
        ChangeValue(slider.value);
    }

    void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
    }

    void ChangeValue(float value)
    {
        text.text = value.ToString("n" + decimals) + " " + unit;
        savedValue = value;
        SaveValue();
    }

    void SaveValue()
    {
        PlayerPrefs.SetFloat("SensitivityFactor", savedValue);
        //Debug.Log("saved value is " + savedValue);
    }
	
}
