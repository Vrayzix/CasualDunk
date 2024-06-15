using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Counter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private SoundsManager soundsManager;
    public Throw Throw;
    public int Count = 0;
    public static int Score = 0;
    public Transform cam;
    private float farDistance;
    public ParticleSystem scoreEffect;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Scene")
        {
            Count = 0;
            Score = 0;

            soundsManager = FindObjectOfType<SoundsManager>();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            scoreText.text = "Score : " + Score;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Scored Object"))
        {
            Count += 1;
            Counter.Score += 25;
            other.gameObject.tag = "Scored Object";
            scoreEffect.Play();
            soundsManager.audioSource.PlayOneShot(soundsManager.scoredSound, 1f);
            StartCoroutine(delayToNextLVL());

            if (Count > 8)
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Won");
            }
        }
    }

    IEnumerator delayToNextLVL()
    {
        Throw.canShoot = false;
        yield return new WaitForSeconds(2f);
        farDistance += -3f;
        cam.transform.position += new Vector3(0f, 0f, farDistance);
        Throw.canShoot = true;
    }
}
