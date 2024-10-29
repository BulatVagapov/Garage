using DG.Tweening;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Vector3 clocedDoorAngles = Vector3.zero;
    private Vector3 openedDoorAngles = new Vector3(-80, 0, 0);

    public bool IsOpen { get; private set; }

    public void OpenDoor()
    {
        transform.DORotate(openedDoorAngles, 3f);
        IsOpen = true;
    }

    public void CloseDoor()
    {
        transform.DORotate(clocedDoorAngles, 3f);
        IsOpen = false;
    }
}
