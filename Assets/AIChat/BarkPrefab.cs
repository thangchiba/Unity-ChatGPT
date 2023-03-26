using TMPro;
using UnityEngine;

namespace MMORPG.UI.AIChat
{
    //Show bag on top
    public class BarkPrefab
    {
        [SerializeField]  private TextMeshProUGUI barkContent;

        public void StartBark()
        {
            
        }

        public void SetContent(string content)
        {
            barkContent.text = content;
        }
    }
}