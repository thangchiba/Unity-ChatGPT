using UnityEngine;
using UnityEngine.Events;

namespace MMORPG.UI
{
    public class ShowHideUI : MonoBehaviour
    {
        [SerializeField] KeyCode showKey = KeyCode.Return;
        [SerializeField] KeyCode hideKey = KeyCode.Escape;
        [SerializeField] GameObject uiContainer;
        [SerializeField] UnityEvent onShow = null;
        [SerializeField] UnityEvent onHide = null;

        // Start is called before the first frame update
        void Start()
        {
            if (uiContainer != null)
                uiContainer?.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(showKey))
            {
                SetActive(true);
            }
            if (Input.GetKeyDown(hideKey))
            {
                SetActive(false);
            }
        }

        public void SetActive(bool isActive)
        {
            if (uiContainer != null)
                uiContainer?.SetActive(isActive);
            onShow?.Invoke();
        }
    }
}