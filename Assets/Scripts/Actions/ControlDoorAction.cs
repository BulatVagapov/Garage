using UnityEngine;

public class ControlDoorAction : AbstractAction
{
    [SerializeField] private DoorOpener door;

    protected override string ActionString { get => door.IsOpen? closeDoor: openDoor; }

    private string openDoor = "E \n Open";
    private string closeDoor = "E \n Close";
    
    protected override void DoAction()
    {
        if (!door.IsOpen)
        {
            door.OpenDoor();
            actionText.text = closeDoor;
        }
        else
        {
            door.CloseDoor();
            actionText.text = openDoor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AddActionToplayer();
    }

    private void OnTriggerExit(Collider other)
    {
        RemoveActionFromPlayer();
    }
}
