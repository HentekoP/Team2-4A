using UnityEngine;
using Random = System.Random;

namespace Project.Scripts.Breaks //�Q�Ƃ��₷���悤�ɂ��Ă���
{
    public class FractureThis : MonoBehaviour
    {
        [SerializeField] private Anchor anchor = Anchor.Bottom; //�Œ肷��ꏊ
        [SerializeField] private int chunks = 500;  //�j�Ђ̐�
        [SerializeField] private float density = 50;    //�j�Г��m�̂�������
        [SerializeField] private float internalStrength = 100;  //�ǂ̑ϋv�l

        [SerializeField] private Material insideMaterial;   //���g�̐F
        [SerializeField] private Material outsideMaterial;  //�O���̐F

        private Random rng = new Random();

        private void Start()
        {
            FractureGameobject();
            gameObject.SetActive(false);
        }

        public ChunkGraphManager FractureGameobject()   //�\������ꏊ�ƕ\������I�u�W�F�N�g�����߂�
        {
            var seed = rng.Next();
            return Fracture.FractureGameObject(
                gameObject,         //���̃X�N���v�g�����Ă���I�u�W�F�N�g
                anchor,             //�Œ肷��ꏊ
                seed,               //�I�u�W�F�N�g�̏o���ʒu
                chunks,             //�j�Ђ̐�
                insideMaterial,     //���g�̐F
                outsideMaterial,    //�O���̐F
                internalStrength,   //�I�u�W�F�N�g�̑ϋv�l
                density             //�j�Ђǂ����̂Ȃ���
            );
        }
    }
}