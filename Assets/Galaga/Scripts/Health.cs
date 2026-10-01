using UnityEngine;

namespace Galaga
{
    public class Health : MonoBehaviour
    {
        [SerializeField, Min(0f)]
        public int maxHP = 5;
        public int HP;
        public bool isAlive = true;

        void Awake()
        {
            HP = maxHP;
        }

        public void Damage(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                HP = 0;
                isAlive = false;
            }
        }
    }
}
