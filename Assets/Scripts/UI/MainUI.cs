using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;

        private InterfaceHandler _interfaceHandler;
        
        [Inject]
        private void Construct(InterfaceHandler interfaceHandler)
        {
            _interfaceHandler = interfaceHandler;
        }

        private void OnEnable()
        {
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnDisable()
        {
            _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }

        private void OnMainMenuButtonClicked()
        {
            _interfaceHandler.ShowMainMenuWindow();
        }
    }
}