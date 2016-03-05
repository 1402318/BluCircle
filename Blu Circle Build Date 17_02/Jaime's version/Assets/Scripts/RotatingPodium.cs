using UnityEngine;
using System.Collections;

public class RotatingPodium : MonoBehaviour 
{
    /*this script will be used to switch textures on cat model */
    public GameObject CatDisplayObject;

    public Texture[] MyTextures;

    private int arrayPos;
    public void Start()
    {
    }
    private void UpdateMaterials()
    {
        if (Input.GetMouseButtonDown(0) && MyTextures.Length > 0)
        {
            arrayPos++;
            arrayPos %= MyTextures.Length;
            CatDisplayObject.gameObject.GetComponent<Renderer>().material.mainTexture = MyTextures[arrayPos];
        }
    }

    void Update()
    {
        UpdateMaterials();
    }
}
