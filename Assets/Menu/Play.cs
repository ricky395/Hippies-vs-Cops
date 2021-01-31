using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {

	void OnMouseDown()
    {
        try
        {
            GetComponent<AudioSource>().Play();
        }
        catch
        {
            
        }

        Invoke("Changescene", .5f);
    }

    void Changescene()
    {
        Scene sc = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sc.buildIndex + 1);
    }

}
