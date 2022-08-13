using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PixelGame.Touch;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCharacterController : Character
{
    public UnityAction GoalAchieved;

    [SerializeField] private float m_StoppingDistance = 0f;
    [SerializeField] private float m_Speed = 2f;
    private Queue<Vector2> m_WorldPosition { get; set; }
    private Rigidbody2D m_Physics { get; set; }

    private Vector2 m_Position;

    private void Initialize()
    {
        m_Physics = GetComponent<Rigidbody2D>();

        m_Position = m_Physics.position;

        m_WorldPosition = new Queue<Vector2>();
    }

    private void Start() => Initialize();

    private void OnEnable() => SystemTouch.OnClick += OnPointerClick;

    private void OnDisable() => SystemTouch.OnClick -= OnPointerClick;

    private void OnPointerClick(Vector2 worldPosition) => m_WorldPosition.Enqueue(worldPosition);

    private void FixedUpdate()
    {
        Movement(Time.fixedDeltaTime);
    }
    private void Movement(float delta)
    {
        if (!m_WorldPosition.TryPeek(out m_Position)) return;

        Func<Vector2, Vector2, float> magnitude = (Vector2 a, Vector2 b) => (a - b).sqrMagnitude;
        float distance = magnitude(m_Position, m_Physics.position);

        if (distance <= m_StoppingDistance)
        {
            m_WorldPosition.Dequeue();
            GoalAchieved?.Invoke();
            return;
        }

        Vector2 movePosition = Vector2.MoveTowards(m_Physics.position, m_Position, m_Speed * delta);
        m_Physics.MovePosition(movePosition);
    }
}
