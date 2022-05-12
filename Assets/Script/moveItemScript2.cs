using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveItemScript2 : MonoBehaviour
{
    public GameObject player;
    public Text itemText1, itemText2;
    public Image stage_1;

    LayerMask mask;
    GameObject item1;
    RaycastHit hit;

    CubeScript2 sc_item1;
    public static bool grab;
    Vector3 item_up;
    Rigidbody rb_item1;
    Collider col_item1;

    [SerializeField] AudioClip[] se;
    protected AudioSource source;

    // Start is called before the first frame update
    void Start()
    {

        mask = 1 << 8;
        grab = false;
        itemText1.text = "";
        itemText2.text = "";

        // アタッチしたオーディオソースのうち1番目を使用する
        source = GetComponents<AudioSource>()[0];

        stage_1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(player.transform.position, player.transform.transform.forward, out hit, 2.2f, mask))
        {

            if (grab) // ものを持っているとき
            {

                stage_1.gameObject.SetActive(false);

                sc_item1.ray = true;

                Debug.DrawRay(player.transform.position, player.transform.transform.forward * hit.distance, Color.yellow);
                item1.gameObject.transform.parent = this.gameObject.transform;
                //item1.transform.position = hit.point; // アイテムをレイの当たったところに移動
                ////item1.transform.rotation = Quaternion.FromToRotation(item_up, hit.normal);
                //item1.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal); // アイテムの上方向をレイが当たったところの表面の法線方向にする
                //item1.transform.position += item1.transform.localScale.y / 1.98f * hit.normal; // アイテムが埋まらないように、表面方向に少し動かす

                if (Input.GetButtonDown("X") && sc_item1.ray && !sc_item1.trigStay && sc_item1.grab) // アイテムを置く
                {
                    grab = false;
                    sc_item1.grab = false;
                    col_item1.isTrigger = false;
                    rb_item1.useGravity = true;
                    rb_item1.isKinematic = false;
                    item1.layer = LayerMask.NameToLayer("Cube"); //「Default」レイヤーをつける
                    item1.gameObject.transform.parent = null;
                }

            }
            else
            { // 持ってない時

                stage_1.gameObject.SetActive(true);
                //itemText1.text =  hit.collider.name; // オブジェクトの名前を表示
                //itemText2.text =  hit.collider.name; // オブジェクトの名前を表示

                if (Input.GetButtonDown("X") && hit.collider.tag == "Item") // アイテムを持ち上げる
                {
                    grab = true;
                    item1 = hit.collider.gameObject;
                    sc_item1 = item1.GetComponent<CubeScript2>();
                    sc_item1.grab = true;
                    source.PlayOneShot(se[0]);

                    //sc_item1.transform.rotation = Quaternion.Euler(Vector3.zero); // 回転をリセット

                    // リジッドボディ
                    rb_item1 = item1.GetComponent<Rigidbody>();
                    rb_item1.useGravity = false;
                    rb_item1.isKinematic = true;

                    // コライダー
                    col_item1 = item1.GetComponent<Collider>();
                    col_item1.isTrigger = true;

                    //item_up = item1.transform.up; // 持ったときのアイテムの上方向を記憶
                    item1.layer = LayerMask.NameToLayer("Cube"); //「Cube」レイヤーをつける

                    itemText1.text = "";
                    itemText2.text = "";

                }
            }
        }
        else
        {

            stage_1.gameObject.SetActive(false);
            //itemText1.text = null; // オブジェクトの名前を非表示
            //itemText2.text = null; // オブジェクトの名前を非表示
            if (grab)
            {
                sc_item1.ray = false;
            }
        }
    }
    public static bool GetGrabFlg()
    {
        return grab;
    }
}