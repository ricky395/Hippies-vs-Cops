using UnityEngine;
using System.Collections;

public class StartResolution : MonoBehaviour
{
    int height;
    int width;
    int size = 64;
    int newRes;
    bool isF11Down = false;

    void Start()
    {
        GetComponent<Camera>().orthographicSize = 6.4f;
        GetComponent<Camera>().backgroundColor = Color.black;

        Resolution[] res = Screen.resolutions; //obtengo resoluciones de la pantalla actual

        if (res[res.Length - 1].height >= 1000)
            height = res[res.Length - 4].height;

        else height = res[res.Length - 1].height;

        newRes = height / size;
        newRes *= size;

        Screen.SetResolution(newRes, newRes, false); //establezco la maxima resolucion disponible newRes * size

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            if (isF11Down)
            {
                Screen.SetResolution(newRes, newRes, false);
                isF11Down = false;
            }

            else
            {
                Screen.SetResolution(newRes, newRes, true);
                isF11Down = true;
            }
        }
    }

}