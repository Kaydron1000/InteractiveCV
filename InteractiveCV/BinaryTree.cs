using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveCV
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Parent { get; set; }
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightSibling { get; set; }

        public TreeNode(T value, TreeNode<T> parent = null)
        {
            Value = value;
            Parent = parent;
            LeftChild = null;
            RightSibling = null;
        }
    }

    public class BinaryTree<T>
    {
        public TreeNode<T> Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        public void AddRoot(T value)
        {
            Root = new TreeNode<T>(value);
        }

        public TreeNode<T> AddChild(TreeNode<T> parent, T value)
        {
            if (parent == null)
                throw new ArgumentNullException("parent");

            var child = new TreeNode<T>(value, parent);
            if (parent.LeftChild == null)
                parent.LeftChild = child;
            else
            {
                var temp = parent.LeftChild;
                while (temp.RightSibling != null)
                    temp = temp.RightSibling;
                temp.RightSibling = child;
            }
            return child;
        }
    }
}
