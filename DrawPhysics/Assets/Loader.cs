using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private int frames = 0;

    void Update()
    {
        frames++;
        if (frames == 200)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
