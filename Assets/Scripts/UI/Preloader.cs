using UnityEngine;
using Zenject;

namespace UI
{
    public class Preloader :MonoBehaviour
    {
        private InterfaceController _interfaceController;
        
        [Inject]
        private void Construct(InterfaceController interfaceController)
        {
            gameObject.SetActive(true);
            _interfaceController = interfaceController;
            
            AfterConstruct();
        }

        private void AfterConstruct() =>
            _interfaceController.HidePreloaderEvent += Hide;

        private void Hide() => 
            gameObject.SetActive(false);
    }
}