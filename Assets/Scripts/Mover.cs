using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;

    private int _currentPointIndex;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _path.GetChild(i);
    }

    public void Update()
    {
        Transform pointTarget = _points[_currentPointIndex];

        transform.LookAt(pointTarget.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, pointTarget.position, _speed * Time.deltaTime);

        if (transform.position == pointTarget.position)
            ChangePoint();
    }

    public void ChangePoint()
    {
        _currentPointIndex = (_currentPointIndex + 1) % _points.Length;
    }
}