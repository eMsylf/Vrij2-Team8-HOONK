using UnityEngine;

public class CameraIndicator : MonoBehaviour {
    public bool ShowIndicator;
    [Range(.2f, 1f)]
    public float IndicatorSize = .5f;

    public Camera MainCamera;

    private void OnDrawGizmos() {
        if (!ShowIndicator) {
            return;
        }
        Vector3 cubeSize = new Vector3(IndicatorSize, IndicatorSize, IndicatorSize);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, cubeSize);
        Gizmos.DrawLine(transform.position, transform.position + transform.up * GetComponent<CameraFollow>().CameraDistance);
        Gizmos.DrawWireSphere(transform.position + transform.up * GetComponent<CameraFollow>().CameraDistance, IndicatorSize);
    }
}
