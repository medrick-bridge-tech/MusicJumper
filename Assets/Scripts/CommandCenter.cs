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
    [SerializeField][Range(20f,180f)] float BPM;
    public List<MusicFrame> MusicNote = new List<MusicFrame>();
    [SerializeField] GameObject Platform;
    List<Color> ColorList = new List<Color>();
    List<string> NotesName = new List<string>
    {
        "A","Bb","B","C1","D1","E1","F1","G1","A1","B1","C2","D2","E2","F2","G2","A2","B2","-"
    };

    private GameObject lastObject;
    private bool isContinuous= false;
    private int lastIndex = -4;
    private float percentPerBPM;

    Jumper player;
    public float GetPercentPerBMP()
    {
        return percentPerBPM;
    }
    void Start()
    {
        ColorList = new List<Color>{Color.blue,CreateColor(163f,73f,164f),Color.red,CreateColor(255f,127f,39f),Color.yellow,Color.green,CreateColor(34f,177f,76f)};

        percentPerBPM = Mathf.InverseLerp(20f, 120f, BPM);

        float jumpValue = Mathf.Lerp(28f, 12f, percentPerBPM);
        float speedValue = Mathf.Lerp(10f, 20f, percentPerBPM);
        player = FindObjectOfType<Jumper>();

        player.setJumpForce(jumpValue);
        player.setMoveSpeed(speedValue);
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
            noteIndex = NotesName.IndexOf(MusicSheet[i + 1]);
            MusicFrame frame = new MusicFrame(index, noteIndex);
            MusicNote.Add(frame);
        }
    }

    void DisplayPlatforms()
    {
        
        foreach (MusicFrame frame in MusicNote)
        {

            Debug.Log($"{frame.GetIndex()},{frame.GetNote()}");

            if (frame.GetIndex() - lastIndex <= 3f)
            {
                isContinuous = true;
            }
            else
            {
                isContinuous= false;
            }

            Create(frame.GetIndex(), frame.GetNote());
            lastIndex = frame.GetIndex();
            
            
            
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
        
        float Y = (2*(1/(BPM/60))*Index) - (Camera.main.orthographicSize / 2);
        
        if (isContinuous)
        {
            randomX = lastObject.transform.position.x;
        }

        GameObject platform = Instantiate(Platform, new Vector2(randomX, Y), Quaternion.identity);
        lastObject = platform;
        platform.GetComponent<Platform>().SetNote(noteIndex);
        platform.GetComponent<SpriteRenderer>().color = ColorList[noteIndex%7] ;
    }
}
