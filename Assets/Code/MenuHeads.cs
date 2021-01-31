using UnityEngine;
using UnityEngine.EventSystems;

public class MenuHeads : MonoBehaviour
{
    public GameObject sprite;
    public Object hippie;
    public int cost = 3;
    GameObject spriteObj;
    UnselectManager um;
    MoneyManager mm;
    bool canBuy = false;
    SelectionManager sm;
    BoxCollider2D boxSelector;
    public bool isStrong;
    public bool isFlower;
    AudioLibrary aL;
    SpriteRenderer[] childrenRenderer;
    bool headsEnabled = false;

    void Start()
    {
        GameObject sceneManager = GameObject.Find("SceneManager");

        um = sceneManager.GetComponent<UnselectManager>();
        mm = sceneManager.GetComponent<MoneyManager>();
        boxSelector = GetComponent<BoxCollider2D>();
        aL = GameObject.Find("SoundsManager").GetComponent<AudioLibrary>();
        
    }

    void Update()
    {
        if (headsEnabled)
        {
            if (cost > mm.GetTotalMoney()) //en caso de tener dinero para comprar el hippie
            {
                childrenRenderer[1].GetComponent<SpriteRenderer>().enabled = false;
                boxSelector.enabled = false; //activo el boxcollider para poder comprar
                canBuy = false;
            }

            else
            {
                childrenRenderer[1].GetComponent<SpriteRenderer>().enabled = true;
                sprite.GetComponent<SpriteRenderer>().sortingOrder = 5;
                boxSelector.enabled = true;
                canBuy = true;
            }
        }        
    }

    public void BoxSelected(SelectionManager selectionScript)
    {
        sm = selectionScript;
        spriteObj = (GameObject)Instantiate(sprite, this.transform.position, new Quaternion(0, 0, 0, 0));
        
        headsEnabled = true;
        childrenRenderer = spriteObj.GetComponentsInChildren<SpriteRenderer>();
    }

    public void BoxUnselected()
    {
        sm = null;
        Destroy(spriteObj);
        boxSelector.enabled = false;
        headsEnabled = false;
    }

    void OnMouseDown()
    {
        if (canBuy && !sm.GetIsHippie())
        {
            if (isStrong)
                sm.TryInstantiate(hippie, new Vector2(sm.transform.position.x + 1.3f, sm.transform.position.y + 0.5f));

            else if (isFlower)
                sm.TryInstantiate(hippie, new Vector2(sm.transform.position.x + 0.001f, sm.transform.position.y));

            else
                sm.TryInstantiate(hippie, new Vector2(sm.transform.position.x, sm.transform.position.y - 0.0999f));

            aL.PlaySpawn();
            um.UnselectBox();
            mm.OddMoney(cost);
            canBuy = false;
        }
    }

}
