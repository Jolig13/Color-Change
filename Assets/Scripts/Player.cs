using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{   
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color pinkColor;
    [SerializeField] private Color violetColor;
    [SerializeField] private Color cyanColor;
    private string currentColor;
    private Rigidbody2D rb2D;
    private SpriteRenderer sprite;
    private float delay = 1f;
    [SerializeField] private  ParticleSystem particle;

    [SerializeField] private float jumpForce;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();  
        ColorCHange();         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.velocity = Vector2.zero;   
            rb2D.AddForce(new Vector2(0f,jumpForce));
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {   
        if (other.gameObject.CompareTag("ColorChanger"))
        {
            ColorCHange();
            Destroy(other.gameObject);
            return;
        }
        if(other.gameObject.CompareTag("FinishLine"))
        {
            gameObject.SetActive(false);
            Instantiate(particle,transform.position,Quaternion.identity);
            Invoke("LoadNextScene",delay);
            return;
        }
        if (!other.gameObject.CompareTag(currentColor))
        {  
            Instantiate(particle,transform.position,Quaternion.identity);
            gameObject.SetActive(false);
            Invoke("RestartScene",delay);
        }    
    }
    private void ColorCHange()
    {   
        int randomNumber = Random.Range(0,4);
        if (randomNumber == 0)
        {
            sprite.color = yellowColor;
            currentColor = "yellow";
        }
        else if (randomNumber == 1)
        {
            sprite.color = pinkColor;
            currentColor = "pink";
        }
        else if (randomNumber == 2)
        {
            sprite.color = violetColor;
            currentColor = "violet";
        }
        else if (randomNumber == 3)
        {
            sprite.color = cyanColor;
            currentColor ="cyan";
        }
    }
    private void LoadNextScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex+1);
    }
    private void RestartScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }
}

