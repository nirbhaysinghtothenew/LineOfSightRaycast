using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Script
{
    public class GameOverPopup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI resultText;
       
        public void UpdateResultText(string text)
        {
            resultText.text = text;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}