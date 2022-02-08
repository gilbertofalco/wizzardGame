using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPC : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rbd;
    public float velocidade = 5;
    public float pulo = 250;
    public float queda = -0.2f;
    private bool chao = false;
    private bool direita = true;
    public LayerMask mascara;
    public GameObject pe;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        chao = true;
        transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        chao = false;
        transform.parent = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Inimigo")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float velY;

        if (x == 0)
            anim.SetBool("parado", true);
        else
            anim.SetBool("parado", false);

        if (x < 0 && direita || !direita && x > 0)
        {
            direita = !direita;
            transform.Rotate(new Vector2(0, 180));

        }


        if (chao)
            velY = 0;
        else
            velY = rbd.velocity.y;

        if (rbd.velocity.y < 0)
            rbd.velocity = new Vector2(x * velocidade, rbd.velocity.y + queda);
        else
            rbd.velocity = new Vector2(x * velocidade, rbd.velocity.y);




        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            chao = false;
            rbd.AddForce(new Vector2(0, pulo));
        }

        RaycastHit2D hit;
        hit = Physics2D.Raycast(pe.transform.position, -pe.transform.up, 0.5f, mascara);
        if (hit.collider != null)
            Destroy(hit.collider.gameObject);
        
		
		
    }
}
