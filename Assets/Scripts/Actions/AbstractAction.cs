using TMPro;
using UnityEngine;
using Zenject;

public abstract class AbstractAction : MonoBehaviour
{
    [Inject] protected Character player;
    [Inject] protected TMP_Text actionText;

    protected virtual string ActionString { get; set; }

    protected abstract void DoAction();
    protected virtual void AddActionToplayer()
    {
        player.PlayerAction.AddListener(DoAction);
        actionText.text = ActionString;
        actionText.gameObject.SetActive(true);
    }

    protected virtual void RemoveActionFromPlayer()
    {
        player.PlayerAction.RemoveListener(DoAction);
        actionText.gameObject.SetActive(false);
    }
}
