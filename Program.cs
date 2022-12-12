using System;

class Program
{
    public static Tree<string> Tree = new Tree<string>();
    public static Stack<string> user = new Stack<string>();
    
    static void Main(string[] args)
    {
        Console.WriteLine("Input :");
        string name = Console.ReadLine();
        Tree.AddChild(null,name);
        AddTree(name);

        Tree.GetPreson(Console.ReadLine());
    }

    public static void AddTree(string checkname)
    {
        
        int number = int.Parse(Console.ReadLine());
        if(number != 0){

            string name = Console.ReadLine();
            Tree.AddChild(checkname,name);
            AddTree(name);
            user.Push(name);

            if(number >= 1){
                for(int i = 1 ;i < number ; i++){
                    string name1 = Console.ReadLine();
                    Tree.AddSibling(user.Pop(),name1);
                    AddTree(name1);
                    user.Push(name1);
                }
            }

        }
    }
    
}