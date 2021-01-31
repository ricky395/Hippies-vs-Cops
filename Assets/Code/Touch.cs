using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour
{

    private Ray ray;

    private RaycastHit hit;

    public Transform hitTransform;

    int z;
    int i;
    private GameObject[,] goName = new GameObject[5, 4];
    private string hitName;
    private int rowEnd = 4;
    private int columnEnd = 3;
    private bool inMenu = false;

    void Start()
    {

    }

    void Update()
    {
#if UNITY_ANDROID
        if (Input.touchCount == 1 ||
            Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                hitTransform = hit.transform.GetComponent<Transform>();

            }
        }
#endif
    }


    void ChooseSquare(Transform hitTransform)
    {


        hitName = hitTransform.name;

        for (i = 0; i < rowEnd && !inMenu; i++)
        {
            for (z = 0; z < columnEnd && !inMenu; z++)
            {
                string iS = i.ToString();
                string zS = z.ToString();

                if (GameObject.Find(iS + "," + zS).name == hitName)
                {

                }
            }
        }

    }

}
