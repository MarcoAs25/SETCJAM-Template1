using UnityEngine;
//Classe responsavel por criar novos canos em um tempo especificado e adicionar alturas aleatorias ao mesmo 
public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSpawn;
    [SerializeField]
    private float minDeltaPosition = -1f;
    [SerializeField]
    private float maxDeltaPosition = 1f;
    [SerializeField]
    private float timeToSpawn = 2f;
    private float timeElapsed;

    void Start()
    {
        timeElapsed = 0f;
    }

    void Update()
    {
        if (!GameManager.Instance.IsStarted)
            return;

        timeElapsed += Time.deltaTime;
        if(timeElapsed >= timeToSpawn)
        {
            float deltapos = Random.Range(minDeltaPosition, maxDeltaPosition);
            Instantiate(objectToSpawn, (transform.position + Vector3.up*deltapos) , Quaternion.identity);
            timeElapsed = 0f;
        }
    }
}
