using UI;
using UnityEngine;
using Zenject;

namespace Aplication
{
    public class AppBaseInstaller : MonoInstaller
    {
        [SerializeField] private WindowsController windowsController;
        [SerializeField] private MainUI mainUi;
        [SerializeField] private Preloader preloader;
        
        public override void InstallBindings()
        {
            Container.BindInstance(new InterfaceController(windowsController, mainUi, preloader));

        }
    }
}