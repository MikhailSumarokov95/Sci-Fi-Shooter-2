using UnityEngine;

public class RotateMedicineChest : MonoBehaviour
{
    [SerializeField] private float speedRotate = 1f;
    [SerializeField] private float speedTranslate = 1f;
    [SerializeField] private float rangeTranslate = 1f;
    private Transform _medicineTr;
    private float _startYTr;

    private void Start()
    {
        _medicineTr = transform;
        _startYTr = _medicineTr.transform.position.y;
    }

    private void Update()
    {
        _medicineTr.Rotate(Vector3.forward, speedRotate);

        var yTr = Mathf.PingPong(Time.time * speedTranslate, rangeTranslate) + _startYTr;

        _medicineTr.transform.position = new Vector3(_medicineTr.transform.position.x, yTr, _medicineTr.transform.position.z);
    }
}
