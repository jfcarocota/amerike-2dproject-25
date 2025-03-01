using UnityEngine;

namespace Character
{
    public interface ICharacterView
    {
        SpriteRenderer SpriteRenderer { get; }
        Animator Animator { get; }
        Rigidbody2D Rigidbody2D { get; }
    }
}