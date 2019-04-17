using UnityEngine;

public class CameraIndicator : MonoBehaviour {
    public float length = 3f;

    public Camera MainCamera;
    //CameraFollow CameraFollow;

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * MainCamera.GetComponent<CameraFollow>().CameraDistance);
        Gizmos.DrawWireSphere(transform.position + transform.up * MainCamera.GetComponent<CameraFollow>().CameraDistance, .5f);
    }
}
