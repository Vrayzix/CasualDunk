using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundsManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource BGMAudioSource;
    public AudioClip swooshSound;
    public AudioClip scoredSound;
    private static SoundsManager instance;
    private bool isRestarted;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Menu" && !isRestarted)
        {
            BGMAudioSource.Play();
            isRestarted = true;
        }
        else if(SceneManager.GetActiveScene().name == "Scene" && isRestarted)
        {
            isRestarted = false;
        }
    }
}
