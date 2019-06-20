using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public static List<GameObject> lines = new List<GameObject>();

    public static Color currentLineColor = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void win()
    {
        Controller.Win();
        Controller.LoadLevel();
        Controller.Save();
    }

    public void Home()
    {
        Controller.Home();
    }
}
