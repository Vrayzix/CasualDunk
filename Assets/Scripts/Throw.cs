using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throw : MonoBehaviour
{
    public GameObject objectToThrow;
    public float throwingForce;
    public Image forceAmountBar;
    private SoundsManager soundsManager;
    public Counter counter;
    public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        soundsManager = FindObjectOfType<SoundsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (forceAmountBar.fillAmount != 1)
                {
                    throwingForce += 0.08f;
                }
                forceAmountBar.fillAmount += throwingForce / 800;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Shoot();
                throwingForce = 0f;
                forceAmountBar.fillAmount = 0f;
            }
        }
    }

    private void Shoot()
    {
        if (throwingForce > 1f)
        {
            GameObject projectile = Instantiate(objectToThrow, transform.position, transform.rotation);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.AddForce(transform.forward * throwingForce, ForceMode.Impulse);
            soundsManager.audioSource.PlayOneShot(soundsManager.swooshSound, 1f);
        }

    }
}
