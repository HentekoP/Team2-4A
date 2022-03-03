using System.Collections.Generic;   // ISet や HashSet が定義されている
using System.Diagnostics;
using System.Linq;  //ForEach, Select, Whereを使うなら必須
using Project.Scripts.Utils;    // Extensions.cs のこと
using UnityEngine;

namespace Project.Scripts.Breaks //参照しやすいようにしている
{
    public class ChunkGraphManager : MonoBehaviour
    {
        private ChunkNode[] nodes;  //破片の情報一つ一つが入っている配列

        public void Setup(Rigidbody[] bodies)   //破片の情報を格納している
        {
            nodes = new ChunkNode[bodies.Length];
            for (int i = 0; i < bodies.Length; i++)
            {
                var node = bodies[i].GetOrAddComponent<ChunkNode>();
                node.Setup();
                nodes[i] = node;
            }
        }
        
        private void FixedUpdate()
        {
            var runSearch = false;
            foreach (var brokenNodes in nodes.Where(n => n.HasBrokenLinks)) //配列ループ処理　in の後ろの配列の要素が前の変数に格納され、内部の処理を実行後、次の要素に移る
            {
                brokenNodes.CleanBrokenLinks(); //つなぎとめている力が消える処理だと思われる
                runSearch = true;
            }
            
            if(runSearch)
                SearchGraph(nodes);
        }

        private Color[] colors =
        {
            Color.blue, 
            Color.green, 
            Color.magenta, 
            Color.yellow
        };
        
        public void SearchGraph(ChunkNode[] objects)
        {
            var anchors = objects.Where(o => o.IsStatic).ToList();  // Where は foreach文の中でif文を使っているようなもの

            ISet<ChunkNode> search = new HashSet<ChunkNode>(objects);
            var index = 0;
            foreach (var o in anchors)
            {
                if (search.Contains(o)) //Containsは要素の検索
                {
                    var subVisited = new HashSet<ChunkNode>();
                    Traverse(o, search, subVisited);
                    var color = colors[index++ % colors.Length];
                    foreach (var sub in subVisited)
                    {
                        sub.Color = color;
                    }
                    search = search.Where(s => subVisited.Contains(s) == false).ToSet();
                }
            }
            foreach (var sub in search)
            {
                sub.Unfreeze(); //ChunkNodeにある処理
                sub.Color = Color.black;
            }
        }

        private void Traverse(ChunkNode o, ISet<ChunkNode> search, ISet<ChunkNode> visited)
        {
            if (search.Contains(o) && visited.Contains(o) == false)
            {
                visited.Add(o); //ISetのメタデータより

                for (var i = 0; i < o.NeighboursArray.Length; i++)
                {
                    var neighbour = o.NeighboursArray[i];
                    Traverse(neighbour, search, visited);
                }
            }
        }
    }
}