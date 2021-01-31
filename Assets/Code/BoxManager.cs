using UnityEngine;
using System.Collections;

public class BoxManager : MonoBehaviour {
    
    Vector3 boxPos;
    SpriteRenderer boxSpriteRenderer;

    void Start()
    {
        boxPos = GameObject.Find("SelectionBox").GetComponent<Transform>().position;
        boxSpriteRenderer = GameObject.Find("SelectionBox").GetComponent<SpriteRenderer>();
    }
    
    public void SetBoxTransform(Vector3 gridTr)
    {
        boxPos = gridTr;
    }
}
