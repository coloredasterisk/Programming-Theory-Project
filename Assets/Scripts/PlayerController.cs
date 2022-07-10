using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float xRange = 14;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
             speed = 20.0f;
        } else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            speed = 10.0f;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float futurePosition = transform.position.x + (horizontalInput * Time.deltaTime * speed);
        if (Mathf.Abs(futurePosition) < xRange && gameManager.isGameActive) 
        {
            transform.position = new Vector3(futurePosition, 2, -10);
        }
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Vehicle"))
        {
            gameManager.EndGame();
            Destroy(other.gameObject);
            StartCoroutine(DestroyObject(other.gameObject));
        }
    }

    IEnumerator DestroyObject(GameObject other)
    {
        yield return new WaitForSeconds(1);
        
        Time.timeScale = 0;
    }
}
