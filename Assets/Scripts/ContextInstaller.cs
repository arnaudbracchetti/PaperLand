using UnityEngine;
using Zenject;
using Paperland.View;
using Paperland.Controller;

public class ContextInstaller : MonoInstaller
{
    [SerializeField] GameObject _zonePrefab;

    public override void InstallBindings()
    {
        // Les Views
        Container.Bind<IBoardMapView>().To<MapView>().FromComponentInHierarchy().AsSingle();

        //Les controller
        Container.Bind<InputController>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<BoardMap>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<ZoneController>().FromComponentInHierarchy().AsSingle().NonLazy();


        // Les factories
        Container.BindFactory<ZoneView, ZoneFactory>().FromComponentInNewPrefab(_zonePrefab);
    }
}