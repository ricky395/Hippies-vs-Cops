using UnityEngine;
using System.Collections;

public class UnselectManager : MonoBehaviour {
    
    Vector2 outterPos;
    Transform boxPos;
    string prevSelection;
    MenuHeads[] mh = new MenuHeads[4];

	void Start () {
        
        boxPos = GameObject.Find("SelectionBox").GetComponent<Transform>();
        outterPos = boxPos.position;
	}

    void OnMouseDown()
    {
        UnselectBox();
        if (prevSelection != null)
        {
            PrevToFalse();
        }
    }

    public void MenuHeadGetter(MenuHeads[] menuHeads)
    {
        mh = menuHeads;
    }

    public void UnselectBox()
    {
        boxPos.position = outterPos;
        DeleteHeads();        
    }

    void DeleteHeads()
    {
        for (int i = 0; i < 4; i++)
        {
            mh[i].BoxUnselected();
        }
    }

    public void UpdateSelection(SelectionManager currentSelection)
    {
        if (prevSelection != null && currentSelection.name != prevSelection)
        {
            PrevToFalse();
            DeleteHeads();
        }

        prevSelection = currentSelection.name;
    }

    void PrevToFalse()
    {
        GameObject.Find(prevSelection).GetComponent<SelectionManager>().SetActive(false);
    }

    public string GetSelection()
    {
        return prevSelection;
    }
}
