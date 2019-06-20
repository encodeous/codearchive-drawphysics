using System.Collections;
using System.Collections.Generic;
using Assets;
using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI o;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        o.text = "Level " + Controller.currentLevel + "/" + Controller.TotalLevels;
    }
}
