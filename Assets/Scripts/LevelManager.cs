using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<int> levels;

    public List<int> Levels => levels;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
