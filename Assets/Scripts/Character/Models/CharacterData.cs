using System;
using UnityEngine;

namespace Character.Models
{
    [Serializable]
    public class CharacterData : ICharacterData
    {
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float jumpForce;

        public float MoveSpeed => moveSpeed;
        public float JumpForce => jumpForce;
    }
}