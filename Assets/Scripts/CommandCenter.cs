using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFrame
{
    int Index { get; set; }
    int Note { get; set; }
    public int GetIndex()
    {
        return Index;
    }

    public int GetNote()
    {
        return Note;
    }
    public MusicFrame(int index, int note)
    {
        Index = index;
        Note = note;
    }
    
}



public class CommandCenter : MonoBehaviour
{
    public Color CreateColor(float r, float g, float b)
    {
        return new Color(r / 255, g / 255, b / 255);
    }
    // Start is called before the first frame update
    [SerializeField] TextAsset textAsset;
    [SerializeField] string[] MusicSheet;
    [SerializeField] float ScreenWidthX;
    public List<MusicFrame> MusicNote = new List<MusicFrame>();
    [SerializeField] GameObject Platform;


    List<Color> ColorList = new List<Color>();



    
    void Start()
    {
        ColorList = new List<Color>
        {
        Color.blue,CreateColor(163f,73f,164f),Color.red,CreateColor(255f,127f,39f),Color.yellow,Color.green,CreateColor(34f,177f,76f)
        };
        ReadMusic();

        DisplayPlatforms();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadMusic()
    {
        int index;
        int noteIndex;
        string MusicNoteText = (textAsset.text);
        MusicSheet = MusicNoteText.Split(",");
        
        for (int i = 0; i < MusicSheet.Length-1 ; i += 2)
        {
            index = Convert.ToInt32(MusicSheet[i]);
            noteIndex = Convert.ToInt32(MusicSheet[i + 1]);
            MusicFrame frame = new MusicFrame(index, noteIndex);
            MusicNote.Add(frame);
        }
    }

    void DisplayPlatforms()
    {
        foreach (MusicFrame frame in MusicNote)
        {
            Debug.Log($"{frame.GetIndex()},{frame.GetNote()}");
            Create(frame.GetIndex(), frame.GetNote());

            int ListIndex = frame.GetIndex();
            if (ListIndex == 0)
            {
                Vector2 Position = FindObjectOfType<Platform>().transform.position;
                Jumper Player = FindObjectOfType<Jumper>();
                Position.y = Player.transform.position.y;

                Player.transform.position = Position;
            }
        }
    }

    void Create(int Index, int noteIndex)
    {
        float randomX = UnityEngine.Random.Range(-ScreenWidthX, ScreenWidthX - 1f);
        float Y = (2*Index) - (Camera.main.orthographicSize / 2);
        GameObject platform = Instantiate(Platform, new Vector2(randomX, Y), Quaternion.identity);
        platform.GetComponent<Platform>().SetNote(noteIndex);
        platform.GetComponent<SpriteRenderer>().color = ColorList[noteIndex%7] ;
    }
}
