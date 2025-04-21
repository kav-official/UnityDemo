using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D customCursor; // รูป cursor ของคุณ
    public Vector2 hotspot = Vector2.zero; // จุดที่คลิก
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        Cursor.SetCursor(customCursor, hotspot, cursorMode);
    }
}