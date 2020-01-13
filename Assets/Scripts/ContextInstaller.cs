using UnityEngine;
using Zenject;
using Paperland.View;
using Paperland.Controller;
using Paperland.Input;

public class ContextInstaller : MonoInstaller
{
    [SerializeField] GameObject _zonePrefab;

    public override void InstallBindings()
    {
        // Les Views
        Container.Bind<IBoardMapView>().To<BoardMapView>().FromComponentInHierarchy().AsSingle();

        //Les controller
        Container.Bind<InputController>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<BoardMapController>().AsTransient();
        Container.Bind<ZoneController>().AsTransient();


        // Les factories
        Container.BindFactory<ZoneView, ZoneFactory>().FromComponentInNewPrefab(_zonePrefab);


        Container.BindInterfacesAndSelfTo<GameManager>().FromComponentInHierarchy().AsSingle();

        Container.Bind<CreateZoneTool>().FromComponentInHierarchy().AsTransient();
    }
}