using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CommandCenter : MonoBehaviour
{
    
    [FormerlySerializedAs("musicNote")] [SerializeField] Music music;
    [SerializeField] GameObject platform;
    [SerializeField] float screenWidthX;
    List<Color> _colorList = new List<Color>();

    private GameObject _lastObject;
    private bool _isContinuous;
    private int _lastIndex = -4;
    private float _percentPerBpm;
    
    Jumper _player;
    float _bpm;


    private Color CreateColor(float r, float g, float b)
    {
        return new Color(r / 255, g / 255, b / 255);
    }
    void Start()
    {
        _isContinuous = false;
        _colorList = new List<Color> { Color.blue, CreateColor(163f, 73f, 164f), Color.red, CreateColor(255f, 127f, 39f), Color.yellow, Color.green, CreateColor(34f, 177f, 76f) };
        
        _bpm = music.GetBpm();
        _percentPerBpm = Mathf.InverseLerp(20f, 120f,_bpm);

        float jumpValue = Mathf.Lerp(28f, 16f, _percentPerBpm);
        float speedValue = Mathf.Lerp(10f, 20f, _percentPerBpm);
        _player = FindObjectOfType<Jumper>();

        _player.SetJumpForce(jumpValue);
        _player.SetMoveSpeed(speedValue);

        DisplayPlatforms();

    }

    void DisplayPlatforms()
    {
        
        for(int i = 0; i < music.musicSheet.Count; i++)
        {
            int duration = music.musicSheet[i].duration;
            
            Notes noteName = music.musicSheet[i].noteName;
            
            if (duration - _lastIndex <= 3f)
            {
                _isContinuous = true;
            }
            else
            {
                _isContinuous = false;
                
            }
            
            Create(noteName,duration);
            
            _lastIndex = duration;



            
            if (duration == 0)
            {
                Vector2 position = FindObjectOfType<Platform>().transform.position;
                Jumper player = FindObjectOfType<Jumper>();
                var transform1 = player.transform;
                position.y = transform1.position.y;

                transform1.position = position;
            }

        }
        
    }

    void Create(Notes noteName , int noteDuration)
    {
        var randomX = UnityEngine.Random.Range(-screenWidthX, screenWidthX - 1f);

        if (Camera.main != null)
        {
            float y = (2 * (1 / ( _bpm / 60)) * noteDuration) - (Camera.main.orthographicSize / 2);

            if (_isContinuous)
            {
                randomX = _lastObject.transform.position.x;
            }

            GameObject newPlatform = Instantiate(platform, new Vector2(randomX, y), Quaternion.identity);
            _lastObject = newPlatform;
            newPlatform.GetComponent<Platform>().SetNote(noteName);
            newPlatform.GetComponent<SpriteRenderer>().color = _colorList[noteDuration % 7];
        }

        
    }
    
    
}
