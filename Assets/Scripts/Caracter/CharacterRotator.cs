using UnityEngine;
using Zenject;

public class CharacterRotator : MonoBehaviour
{
	[Inject] private PlayerInputActions input;

	[Inject] private Character characterTransform;

	
	public float Sensitivity
	{
		get { return sensitivity; }
		set { sensitivity = value; }
	}
	[Range(0.1f, 9f)] [SerializeField] float sensitivity = 2f;
	[Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
	[Range(0f, 90f)] [SerializeField] float yRotationLimit = 88f;

	Vector2 rotation = Vector2.zero;
	const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
	const string yAxis = "Mouse Y";

    private void Start()
    {

		//input.Enable();
	}

    void Update()
	{
		rotation.x += input.Player.Mouse.ReadValue<Vector2>().x * sensitivity;
		rotation.y += input.Player.Mouse.ReadValue<Vector2>().y * sensitivity;
		rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
		var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
		var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

		/*transform.localRotation = xQuat * yQuat;*/ //Quaternions seem to rotate more consistently than EulerAngles. Sensitivity seemed to change slightly at certain degrees using Euler. transform.localEulerAngles = new Vector3(-rotation.y, rotation.x, 0);
		transform.localEulerAngles = new Vector3(-rotation.y, 0, 0);
		characterTransform.transform.localEulerAngles = new Vector3(0, rotation.x, 0);
	}
}
