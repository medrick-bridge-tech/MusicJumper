using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    //Check Scene to find any platform | if not => Go to next level
    public class CheckScene : MonoBehaviour
    {
        
        private int platformCount;
        private Platform[] _platforms;

        void Start()
        {
            
            StartCoroutine(GetPlatformCount());

        }

        IEnumerator GetPlatformCount()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                _platforms = FindObjectsOfType<Platform>();
                Debug.Log(_platforms.Length);
                platformCount = _platforms.Length;
                if (platformCount == 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                
                }
            }
            
        }

        private void Update(){
            

    }
    }
}