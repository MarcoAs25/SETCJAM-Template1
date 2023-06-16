using UnityEngine;
using UnityEngine.UI;
//Responsavel por trabalhar com a Interface do Usuario
public class UiManager : MonoBehaviour
{

    private Text textScore;
    //pega o primeiro componente Text que encontrar
    //do filho deste gameObject
    //seta o maxScore e adiciona UpdateScore no evento UpdateScore
    void Start()
    {
        textScore = GetComponentInChildren<Text>();
        textScore.text = PlayerPrefs.GetInt("maxScore").ToString();
        ScoreManager.Instance.onScoreChange.AddListener(UpdateScore);
    }

    private void UpdateScore(int value)
    {
        textScore.text = value.ToString();
    }
}
