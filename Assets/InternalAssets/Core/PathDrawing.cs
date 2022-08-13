using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelGame.Touch;

[RequireComponent(typeof(LineRenderer))]
public class PathDrawing : MonoBehaviour
{
    [SerializeField] private PlayerCharacterController m_Target;
    private LineRenderer m_Line;
    private List<Vector3> m_Points;


    private void Start()
    {
        m_Line = GetComponent<LineRenderer>();
        m_Points = new List<Vector3>();

        AddPosition(m_Target.transform.position);
    }

    private void Update()
    {
        m_Line.SetPosition(0, m_Target.transform.position);
    }

    private void OnEnable()
    {
        SystemTouch.OnClick += OnPointerClick;
        m_Target.GoalAchieved += RemoveZeroPosition;
    }

    private void OnDisable()
    {
        SystemTouch.OnClick -= OnPointerClick;
        m_Target.GoalAchieved -= RemoveZeroPosition;
    }

    private void OnPointerClick(Vector2 position) => AddPosition(position);

    private void AddPosition(Vector2 position)
    {
        m_Points.Add(position);
        m_Line.positionCount++;
        m_Line.SetPositions(m_Points.ToArray());
    }

    private void RemoveZeroPosition()
    {
        m_Points.RemoveAt(0);
        m_Line.positionCount--;
        m_Line.SetPositions(m_Points.ToArray());
    }
}
