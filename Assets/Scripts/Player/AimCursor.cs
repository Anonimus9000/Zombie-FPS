using UnityEngine;

public class AimCursor : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private int _layerMask;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _layerMask = LayerMask.GetMask("Map");
    }

    private void Update()
    {
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit, 1000, _layerMask))
            _spriteRenderer.enabled = false;
        else {
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            _spriteRenderer.enabled = true;
        }
    }
}
