using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {
	public bool lookTarget;
	public Transform target;
	public Vector3 Offset;
	public float positionSmooth = 15F;
	public float rotationSmooth = 15F;
	private Vector3 positionVelocity;
	private Quaternion rotationVelocity;
	private Quaternion lookAtRotation;
	private RaycastHit hit;
	void FixedUpdate() {
		if (lookTarget) {
			if (Physics.Raycast (transform.position, transform.forward, out hit, 5.0f)) {
				lookTarget = false;
			} else {
				lookTarget = true;
			}
		}

		if (lookTarget) {
			Quaternion targetRotation = Quaternion.LookRotation (target.transform.position - transform.position);
			lookAtRotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);
		} else {
			lookAtRotation = Quaternion.Slerp (transform.rotation, new Quaternion(0,0,0,0), Time.deltaTime * rotationSmooth);
		}
		float newXPosition = Mathf.SmoothDamp(transform.position.x, target.position.x, ref positionVelocity.x, positionSmooth/100);
		float newYPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref positionVelocity.y, positionSmooth/100);
		float newZPosition = Mathf.SmoothDamp(transform.position.z, target.position.z, ref positionVelocity.z, positionSmooth/100);
		transform.position = new Vector3(newXPosition, newYPosition, newZPosition) + Offset;
		float newXRotation = Mathf.SmoothDampAngle(transform.rotation.x, target.rotation.x, ref rotationVelocity.x, rotationSmooth/100);
		float newYRotation = Mathf.SmoothDampAngle(transform.rotation.y, target.rotation.y, ref rotationVelocity.y, rotationSmooth/100);
		float newZRotation = Mathf.SmoothDampAngle(transform.rotation.z, target.rotation.z, ref rotationVelocity.z, rotationSmooth/100);
		float newWRotation = Mathf.SmoothDampAngle(transform.rotation.w, target.rotation.w, ref rotationVelocity.w, rotationSmooth/100);
		transform.rotation = new Quaternion(newXRotation + lookAtRotation.x, newYRotation + lookAtRotation.y, newZRotation + lookAtRotation.z, newWRotation + lookAtRotation.w);
	}
}