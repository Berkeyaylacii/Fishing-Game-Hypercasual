using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LowpolyAquaticAnimals
{

	public class CameraController : MonoBehaviour
	{
		float _rotateValue = 1f;
		float _zoomValue = 1f;

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				transform.Rotate(Vector3.up, _rotateValue);
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.Rotate(Vector3.up, -_rotateValue);
			}

			if (Input.GetKey(KeyCode.UpArrow))
			{
				Camera.main.fieldOfView -= _zoomValue;
			}

			if (Input.GetKey(KeyCode.DownArrow))
			{
				Camera.main.fieldOfView += _zoomValue;
			}
		}
	}
}
