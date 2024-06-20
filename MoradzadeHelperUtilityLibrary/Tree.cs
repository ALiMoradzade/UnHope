using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MoradzadeHelperUtilityLibrary
{
    public class Tree
    {
        Node root;
        public Node Root { get => root; }
        public Node[] Leaves { get => GetNodesByDFS(root).Where(x => x.ChildrenCount == 0).ToArray(); }
        
        public Tree(Node root)
        {
            this.root = root;
            this.root.level = 0;
        }

        public string TraverseDFS(string seprator = " ")
        {
            List<Node> nodes = GetNodesByDFS(root).ToList();
            string[] s = nodes.Select(x => $"{string.Concat(Enumerable.Repeat(seprator, x.level))}{x.Key}: {x.Value}").ToArray();
            return string.Join("\r\n", s);
        }

        List<Node> GetNodesByDFS(Node node)
        {
            List<Node> s = new List<Node> { node };
            foreach (var item in node)
            {
                s.AddRange(GetNodesByDFS(item));
            }
            return s;
        }
    }
    public class Node
    {
        string key;
        object value;
        internal int level;
        string path;
        Node parent;
        List<Node> children = new List<Node>();

        public Node(string name, object data = null)
        {
            key = name;
            this.value = data;
            path = name;
        }
        public Node(Node node)
        {
            key = node.key;
            value = node.value;
            level = node.level;
            path = node.path;
            parent = node.parent;
            children = node.children.ToList();
        }

        public string Key { get => key; set => key = value; }
        public object Value { get => value; set => this.value = value; }
        public int Level { get => level; }
        public bool hasParent { get => !(parent == null); }
        public string Path { get => path; }
        public Node Parent { get => parent; }
        public ChildrenCollection Children { get => new ChildrenCollection(this); }
        public int ChildrenCount { get => children.Count; }

        public void AddChild(Node childNode)
        {
            childNode.level = this.level + 1;
            childNode.parent = this;
            childNode.path = $"{path}->{childNode.key}";
            children.Add(childNode);
        }
        public void AddChild(string childName)
        {
            AddChild(new Node(childName));
        }
        public void AddChildren(params string[] childrenNames)
        {
            foreach (string nodeName in childrenNames)
            {
                AddChild(nodeName);
            }
        }

        public void DeleteChild(Node node)
        {
            if (children.Contains(node)) children.Remove(node);
        }
        public void DeleteChildAt(int childIndex)
        {
            DeleteChild(children[childIndex]);
        }

        public bool SameAncestorLevel(Node node, int level)
        {
            if (node == null || (string.IsNullOrEmpty(node.path) ^ string.IsNullOrEmpty(path))) return false;
            return GetParentAt(level) == node.GetParentAt(level);
        }

        public Node GetParentAt(int level)
        {
            if (parent.level == level) return parent;
            return parent.GetParentAt(level);
        }
        public override string ToString()
        {
            return key;
        }

        #region Children Collection
        public ChildrenCollection GetEnumerator()
        {
            return new ChildrenCollection(this);
        }

        public class ChildrenCollection
        {
            int index;
            Node node;

            public ChildrenCollection(Node node)
            {
                this.node = node;
                index = -1;
            }

            public Node this[int index] { get => node.children[index]; }
            public Node this[string nodeName] { get => node.children.Where(x => x.key == nodeName).ToList()[0]; }

            public bool MoveNext()
            {
                index++;
                return index < node.children.Count;
            }

            public Node Current => node.children[index];
        }
        #endregion
    }
}
