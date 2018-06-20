using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CursorController : MonoBehaviour {

    public Texture2D defaultCursor;
    public Texture2D activeCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(activeCursor, hotSpot, cursorMode);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, hotSpot, cursorMode);
    }
}
