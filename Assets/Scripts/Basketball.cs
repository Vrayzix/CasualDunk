using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basketball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Scene")
        {
            transform.Rotate(Vector3.up * 2f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject, 1f);

            if (!gameObject.CompareTag("Scored Object") && gameObject.tag != "Grounded" && Counter.Score != 0)
            {
                Counter.Score -= 5;
                gameObject.tag = "Grounded";
            }
        }
    }
}
