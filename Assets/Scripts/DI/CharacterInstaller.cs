using UnityEngine;
using Zenject;

public class CharacterInstaller : MonoInstaller
{
    private CharacterMovement movement => GetComponent<CharacterMovement>();
    private Rigidbody rigidbody => GetComponent<Rigidbody>();

    [SerializeField] private PickUpItemAction pickUpItemAction;
    [SerializeField] private Hand hang;

    public override void InstallBindings()
    {
        Container.Bind<Rigidbody>().FromInstance(rigidbody).AsSingle();
        Container.Bind<CharacterMovement>().FromInstance(movement).AsSingle();
        Container.Bind<Hand>().FromInstance(hang).AsSingle();
        Container.Bind<PlayerInputActions>().AsSingle();
        Container.Bind<PickUpItemAction>().FromInstance(pickUpItemAction).AsSingle();
    }
}