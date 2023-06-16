using UnityEngine;
//Classe responsavel por gerenciar eventos e acoes que acontece com o jogador
//verificar input, adicionar velocidade, detectar colisao, seu tipo e seu tratamento
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    [SerializeField]
    private float velocityUp;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameManager.Instance.onStartChange.AddListener(ChangeBodyType);
    }
    private void ChangeBodyType(bool isStarting)
    {
        anim.SetBool("idle", !isStarting);
        if (isStarting)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            rb2d.bodyType = RigidbodyType2D.Static;
        }
    }

    void Update()
    {
        if (GameManager.Instance.IsStarted)
        { 
            if(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0))
            {
                rb2d.velocity = new Vector3(0f, velocityUp, 0f);
                SoundManager.Instance.PlayTap();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Score"))
        {
            ScoreManager.Instance.AddScore();
            SoundManager.Instance.PlayScore();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Death"))
        {
            #if UNITY_EDITOR
                Debug.Log("Game Over");
#endif
            SoundManager.Instance.PlayHit();
            GameManager.Instance.GameOver();
        }
    }
}
