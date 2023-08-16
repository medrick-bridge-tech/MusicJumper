using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField][Range(0f,10f)] float scrollSpeed;
    private Renderer _render;
    private Vector2 _scrollPosition;
    // Start is called before the first frame update
    void Start()
    {
        _render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(0, y);
        _render.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
