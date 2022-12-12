class Tree<T>
{
    private TreeNode<T> root = null;
    private int length = 0;

    public void AddSibling(T search, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        TreeNode<T> ptr = this.GetTreeNode(search);
        node.SetNext(ptr.Next());
        node.SetParent(ptr.Parent());
        ptr.SetNext(node);
        this.length++;
    }

    public void AddChild(T search, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        if(length == 0)
        {
            node.SetChild(this.root);
            this.root = node;
        }
        else
        {
            TreeNode<T> ptr = this.GetTreeNode(search);
            node.SetChild(ptr.Child());
            node.SetParent(ptr);
            ptr.SetChild(node);
        }
        this.length++;
    }

    public int GetLength()
    {
        return this.length;
    }

    public T Get(T search)
    {
        TreeNode<T> ptr = this.GetTreeNode(search);
        return ptr.GetValue();
    }

    public TreeNode<T> GetTreeNode(T search)
    { 
        return this.Search(search);
    }

    private TreeNode<T> Search(T value)
    {
        Queue<TreeNode<T>> nodeQueue = new Queue<TreeNode<T>>();
        nodeQueue.Push(this.root);

        TreeNode<T> ptr;
        while(nodeQueue.GetLength() > 0)
        {
            ptr = nodeQueue.Pop();
            if(ptr.GetValue().Equals(value))
            {
                return ptr;
            }
            else
            {
                if(ptr.Child() != null)
                {
                    nodeQueue.Push(ptr.Child());
                }
                if(ptr.Next() != null)
                {
                    nodeQueue.Push(ptr.Next());
                }
            }
        }
        return null;
    }

    private TreeNode<T> Traverse(TreeNode<T> currentTreeNode, ref int traverseStep)
    {
        TreeNode<T> ptr = currentTreeNode;
        T test = ptr.GetValue();
        if(traverseStep > 0 && currentTreeNode.Child() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Child(), ref traverseStep);
        }

        if(traverseStep > 0 && currentTreeNode.Next() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Next(), ref traverseStep);
        }
        return ptr;
    }

    public void GetPreson (T search){
            Console.WriteLine("Output :");
            TreeNode<T> node = GetTreeNode(search);
            while(node.Parent() != null){
                T Get = node.Parent().GetValue();
                Console.WriteLine(Get);
                node = node.Parent();
            }
        }
}