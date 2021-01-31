using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour {
    

	public void GameLost()
    {
        SceneManager.LoadScene(0);
    }
}
