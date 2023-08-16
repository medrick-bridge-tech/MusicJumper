using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace DefaultNamespace.Menu
{
    public class SceneLoader : MonoBehaviour
    {


        public void StartGame()
        {
            List<int> levels = FindObjectOfType<LevelManager>().Levels;
            if (levels.Count == 0)
            {
                SceneManager.LoadScene($"Symphony9");
            }
            else
            {
                SceneManager.LoadScene(levels[^1]);
            }
        }

        public void OpenLevels()
        {
            SceneManager.LoadScene(1);
        }
    }
}