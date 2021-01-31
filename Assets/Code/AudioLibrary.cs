using UnityEngine;
using System.Collections;

public class AudioLibrary : MonoBehaviour {

    AudioSource aS;
    public AudioClip spawn;

    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

	public void PlaySpawn()
    {
        aS.PlayOneShot(spawn);
    }
}
