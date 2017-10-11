using UnityEngine;
using System.Collections;

public class CameraThirdPerson : MonoBehaviour {

    public GameObject target;
    public float damping = 1;
    public Vector3 offset, localRotation;
    public float rotationSpeed = 10f;
    float scrollSensitvity = 4f;
    void Start() {
        offset = transform.position - target.transform.position;
        transform.LookAt(target.transform.position);
    }

    void update() {

    }
    
    void LateUpdate() {
        if (Input.GetAxis("Horizontal") != 0) {
            localRotation.y += Input.GetAxis("Horizontal") * this.rotationSpeed;
        } else {
            localRotation.y = 0;
        }
        float step = 0f;
        Vector3 offsetToAdd = new Vector3();

        if (Input.GetAxis("Mouse ScrollWheel") != 0f) {
            step = Input.GetAxis("Mouse ScrollWheel") * scrollSensitvity;
            offsetToAdd =  (offset / offset.magnitude) * (offset.magnitude * 0.1f * step);
        }

        offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * rotationSpeed, Vector3.up) * (offset - offsetToAdd);
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * damping);
        transform.position = target.transform.position + offset;
        transform.LookAt(target.transform.position);
    }
}