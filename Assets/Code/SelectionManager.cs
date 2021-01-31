using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    BoxManager bm;
    Transform boxTr;
    bool isActive = false;
    UnselectManager um;
    MenuHeads[] mh = new MenuHeads[4];
    public int type;
    bool isHippie = false;
    Object Hippie;

    void Start()
    {
        GameObject sceneManager = GameObject.Find("SceneManager");

        boxTr = GameObject.Find("SelectionBox").GetComponent<Transform>();
        bm = sceneManager.GetComponent<BoxManager>();
        um = sceneManager.GetComponent<UnselectManager>();

        for (int i = 0; i < 4; i++)
        {
            mh[i] = GameObject.Find("0" + i.ToString()).GetComponent<MenuHeads>();
        }
        
    }

    void Update()
    {
        if (Hippie == null)
            isHippie = false;
    }

    void OnMouseDown()
    {
        if (!isActive)
        {
            bm.SetBoxTransform(this.transform.position);

            boxTr.position = this.transform.position;
            isActive = true;
            um.UpdateSelection(this);

            for (int i = 0; i < 4; i++)
            {
                mh[i].BoxSelected(this);
            }

            um.MenuHeadGetter(mh);
        }
    }

    public void SetActive(bool state)
    {
        isActive = state;
    }

    public void TryInstantiate(Object obj, Vector2 pos)
    {
        if (!isHippie)
        {
            isHippie = true;
            isActive = false;
            Hippie = Instantiate(obj, pos, new Quaternion(0, 0, 0, 0));
        }
    }

    public bool GetIsHippie()
    {
        return isHippie;
    }
}
