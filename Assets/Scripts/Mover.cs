using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;

    private int _currentPointIndex;

    void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _path.GetChild(i);
    }

    public void Update()
    {
        Transform target = _points[_currentPointIndex];

        transform.LookAt(target.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        
        if (transform.position == target.position)
            ChangePoint();
    }

    public void ChangePoint()
    {
        _currentPointIndex++;

        if (_currentPointIndex == _points.Length)
            _currentPointIndex = 0;
    }
}