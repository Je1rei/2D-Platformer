using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyPatrol : Enemy
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    private int _currentPoint;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();   
        _currentPoint = 0;
    }

    private void FixedUpdate()
    {
        Patrol();
    }

    private void Patrol()
    {
        Transform currentWaypoint = _waypoints[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, _speed * Time.deltaTime);

        if (transform.position == currentWaypoint.position)
        {
            GetNextPoint();
            FlipSprite();
        }
    }

    private Vector3 GetNextPoint()
    {
        _currentPoint = (++_currentPoint) % _waypoints.Length;

        Vector3 waypoint = _waypoints[_currentPoint].transform.position;

        return waypoint;
    }

    private void FlipSprite()
    {
        _spriteRenderer.flipX = _currentPoint % 2 == 0 ? true : false;
    }
}
