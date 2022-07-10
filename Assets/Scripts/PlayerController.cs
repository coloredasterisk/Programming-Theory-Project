using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
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
