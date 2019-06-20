using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class Controller
    {
        public static int currentLevel = 1;
        public static int TotalLevels = 27;

        public static void LoadData()
        {
            var a = PlayerPrefs.GetInt("level");
            if (a<1)
            {
                a = 1;
            }
            currentLevel = a;
        }

        public static void Start()
        {
            LoadData();
            LoadLevel();
        }
        public static void LoadLevel()
        {
            SceneManager.LoadScene("L" + currentLevel);
            
        }

        public static void Win()
        {
            currentLevel++;
            PlayerPrefs.SetInt("level", currentLevel);
        }

        public static void UnloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public static void Save()
        {
            PlayerPrefs.SetInt("level",currentLevel);
        }

        public static void Home()
        {
            Save();
            SceneManager.LoadScene("Main");
        }
    }
}
