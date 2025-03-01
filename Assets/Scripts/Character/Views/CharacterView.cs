using Character.Models;
using UnityEngine;

namespace Character.Views
{
    [RequireComponent(
        typeof(SpriteRenderer), 
        typeof(Animator), 
        typeof(Rigidbody2D))]
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rb2D;

        public SpriteRenderer SpriteRenderer => spriteRenderer;
        public Animator Animator => animator;
        public Rigidbody2D Rigidbody2D => rb2D;
    }
}