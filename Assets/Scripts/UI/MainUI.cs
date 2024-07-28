using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;

        private InterfaceController _interfaceController;
        
        [Inject]
        private void Construct(InterfaceController interfaceController)
        {
            _interfaceController = interfaceController;
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
            _interfaceController.ShowMainMenuWindow();
        }
    }
}