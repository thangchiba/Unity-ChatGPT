/**
 * *********************************************************************
 * © 2023 ThangChiba. All rights reserved.
 * 
 * This code is licensed under the MIT License.
 * 
 * Homepage: https://thangchiba.com
 * Email: thangchiba@gmail.com
 * *********************************************************************
 */

using UnityEngine;
using UnityEngine.Events;

namespace ThangChibaGPT

{
    public class ShowHideUI : MonoBehaviour
    {
        [SerializeField] private KeyCode showKey = KeyCode.Return;
        [SerializeField] private KeyCode hideKey = KeyCode.Escape;
        [SerializeField] private GameObject uiContainer;
        [SerializeField] private UnityEvent onShow;
        [SerializeField] private UnityEvent onHide;

        // Start is called before the first frame update
        private void Start()
        {
            if (uiContainer != null)
                uiContainer?.SetActive(false);
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(showKey)) SetActive(true);
            if (Input.GetKeyDown(hideKey)) SetActive(false);
        }

        public void SetActive(bool isActive)
        {
            uiContainer?.SetActive(isActive);
            if (isActive)
                onShow?.Invoke();
            if (!isActive)
                onHide?.Invoke();
        }
    }
}