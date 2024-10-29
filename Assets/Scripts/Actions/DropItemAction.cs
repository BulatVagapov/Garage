using UnityEngine;

public class DropItemAction : AbstractAction
{
    protected override string ActionString { get => actionString; }

    private string actionString = "E \n Drop item";
    
    protected override void DoAction()
    {
        player.Hand.DropItem(transform);
        RemoveActionFromPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.Hand.ItemInHend) AddActionToplayer();
    }

    private void OnTriggerExit(Collider other)
    {
        if (player.Hand.ItemInHend) RemoveActionFromPlayer();
    }
}
