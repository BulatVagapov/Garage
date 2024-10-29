using TMPro;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Character player;
    [SerializeField] private TMP_Text actionText;
    public override void InstallBindings()
    {
        Container.Bind<Character>().FromInstance(player).AsSingle();
        Container.Bind<TMP_Text>().FromInstance(actionText).AsSingle();
    }
}