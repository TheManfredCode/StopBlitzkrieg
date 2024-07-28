using UnityEngine;
using Zenject;

namespace UI
{
    public class Preloader :MonoBehaviour
    {
        private InterfaceHandler _interfaceHandler;
        
        [Inject]
        private void Construct(InterfaceHandler interfaceHandler)
        {
            gameObject.SetActive(true);
            _interfaceHandler = interfaceHandler;
            
            AfterConstruct();
        }

        private void AfterConstruct() =>
            _interfaceHandler.HidePreloaderEvent += Hide;

        private void Hide() => 
            gameObject.SetActive(false);
    }
}