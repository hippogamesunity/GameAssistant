using UnityEngine;
using UnityEngine.UI;

namespace Assets.GameAssistant.Scripts
{
    /// <summary>
    /// Assistant demo scene
    /// </summary>
    public class AssistantDemo : MonoBehaviour
    {
        public InputField Question;
        public Text Answer;
        public TextAsset PreloadedDataEnglish;
        public TextAsset PreloadedDataRussian;

        /// <summary>
        /// Demonstrates assistant functionality
        /// </summary>
        public void Ask()
        {
            const string tableId = "1kxU29-vc2C_xq9qC88HWJlHoak7M5qkngNCfBaU0DhA";
            string sheedId;
            string preloadedCsv = null;

            switch (Application.systemLanguage)
            {
                case SystemLanguage.Russian:
                    sheedId = "2082792765";
                    if (PreloadedDataEnglish != null) preloadedCsv = PreloadedDataEnglish.text;
                    break;
                default:
                    sheedId = "0";
                    if (PreloadedDataEnglish != null) preloadedCsv = PreloadedDataRussian.text;
                    break;
            }

            Question.text = "...";

            var assistant = new Assistant(tableId, sheedId, preloadedCsv);

            assistant.Ask(Question.text, OnSearchCompleted);
        }

        /// <summary>
        /// Open URL
        /// </summary>
        public void Navigate(string url)
        {
            Application.OpenURL(url);
        }

        private void OnSearchCompleted(bool success, string data)
        {
            Answer.text = data;
        }
    }
}