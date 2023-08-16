using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CommandCenter : MonoBehaviour
{
    
    [SerializeField] MusicNote musicNote;
    [SerializeField] GameObject Platform;
    [SerializeField] float ScreenWidthX;
    List<Color> ColorList = new List<Color>();

    private GameObject lastObject;
    private bool isContinuous = false;
    private int lastIndex = -4;
    private float percentPerBPM;

    Jumper player;
    float BPM;
    public float GetPercentPerBMP()
    {
        return percentPerBPM;
    }
    public Color CreateColor(float r, float g, float b)
    {
        return new Color(r / 255, g / 255, b / 255);
    }
    void Start()
    {
        ColorList = new List<Color> { Color.blue, CreateColor(163f, 73f, 164f), Color.red, CreateColor(255f, 127f, 39f), Color.yellow, Color.green, CreateColor(34f, 177f, 76f) };
        BPM = musicNote.GetBPM();
        percentPerBPM = Mathf.InverseLerp(20f, 120f,BPM);

        float jumpValue = Mathf.Lerp(28f, 12f, percentPerBPM);
        float speedValue = Mathf.Lerp(10f, 20f, percentPerBPM);
        player = FindObjectOfType<Jumper>();

        player.setJumpForce(jumpValue);
        player.setMoveSpeed(speedValue);

        DisplayPlatforms();

    }

    void DisplayPlatforms()
    {

        for(int i = 0; i < musicNote.MusicSheet.Count; i++)
        {
            int DURATION = musicNote.MusicSheet[i].duration;
            
            Notes NoteName = musicNote.MusicSheet[i].NoteName;
            
            if (DURATION - lastIndex <= 3f)
            {
                isContinuous = true;
            }
            else
            {
                isContinuous = false;
            }
            
            Create(NoteName,DURATION);
            lastIndex = DURATION;



            int ListIndex = DURATION;
            if (ListIndex == 0)
            {
                Vector2 Position = FindObjectOfType<Platform>().transform.position;
                Jumper Player = FindObjectOfType<Jumper>();
                Position.y = Player.transform.position.y;

                Player.transform.position = Position;
            }

        }
        
    }

    void Create(Notes noteName , int noteDuration)
    {
        float randomX = UnityEngine.Random.Range(-ScreenWidthX, ScreenWidthX - 1f);

        float Y = (2 * (1 / ( BPM / 60)) * noteDuration) - (Camera.main.orthographicSize / 2);
        Debug.Log(Y);

        if (isContinuous)
        {
            randomX = lastObject.transform.position.x;
        }

        GameObject platform = Instantiate(Platform, new Vector2(randomX, Y), Quaternion.identity);
        lastObject = platform;
        platform.GetComponent<Platform>().SetNote(noteName);
        platform.GetComponent<SpriteRenderer>().color = ColorList[noteDuration % 7];
    }
    
    
}
