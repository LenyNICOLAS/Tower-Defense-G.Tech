using UnityEngine;

public class CameraPlacement : MonoBehaviour
{
	// parametres de deplacement de la camera
	public float Speed = 30f;
	public float BorderThickness = 10f;


	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey("z") || Input.GetKey("up") || Input.mousePosition.y >= Screen.height - BorderThickness)
		{
			transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("s") || Input.GetKey("down") || Input.mousePosition.y <= BorderThickness)
		{
			transform.Translate(Vector3.back * Speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("d") || Input.GetKey("right") || Input.mousePosition.x >= Screen.width - BorderThickness)
		{
			transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("q") || Input.GetKey("left") || Input.mousePosition.x <= BorderThickness)
		{
			transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
		}
	}
}
