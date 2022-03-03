using UnityEngine;
using Random = System.Random;

namespace Project.Scripts.Breaks //参照しやすいようにしている
{
    public class FractureThis : MonoBehaviour
    {
        [SerializeField] private Anchor anchor = Anchor.Bottom; //固定する場所
        [SerializeField] private int chunks = 500;  //破片の数
        [SerializeField] private float density = 50;    //破片同士のくっつく力
        [SerializeField] private float internalStrength = 100;  //壁の耐久値

        [SerializeField] private Material insideMaterial;   //中身の色
        [SerializeField] private Material outsideMaterial;  //外側の色

        private Random rng = new Random();

        private void Start()
        {
            FractureGameobject();
            gameObject.SetActive(false);
        }

        public ChunkGraphManager FractureGameobject()   //表示する場所と表示するオブジェクトを決める
        {
            var seed = rng.Next();
            return Fracture.FractureGameObject(
                gameObject,         //このスクリプトがついているオブジェクト
                anchor,             //固定する場所
                seed,               //オブジェクトの出現位置
                chunks,             //破片の数
                insideMaterial,     //中身の色
                outsideMaterial,    //外側の色
                internalStrength,   //オブジェクトの耐久値
                density             //破片どうしのつながり
            );
        }
    }
}