using UnityEngine;
//Classe responsavel por emitir efeitos sonoros (Classe com padrao Singleton)
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField]
    private AudioSource tapSound;
    [SerializeField]
    private AudioSource scoreSound;
    [SerializeField]
    private AudioSource hitSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayScore()
    {
        scoreSound.Play();
    }
    public void PlayTap()
    {
        tapSound.Play();
    }
    public void PlayHit()
    {
        hitSound.Play();
    }
}
