using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMaterials
{
    class Program
    {
        public class ItemNode
        {
            public string name;
            public int ID;
            public int parentID;
            public int NewID;
            public int NewHeaderID;

            // constructor with arguments for creating data
            public ItemNode(string cname, int cID, int cparentID, int cNewID, int cNewHeaderID)
            {
                name = cname;
                ID = cID;
                parentID = cparentID;
                NewID = cNewID;
                NewHeaderID = cNewHeaderID;
            }
        }

        public static ItemNode[] TreeNavigate(ItemNode[] inputTree)
        {
            for (int i = 0; i < inputTree.Length; i++)
            {
                ItemNode currentNode = inputTree[i];
                // if current node has no parent, set newID to its index in the list
                if (currentNode.parentID == -1)
                {
                    // setting to i+1 to account for 0 indexing
                    currentNode.NewID = i + 1;
                    // if the node has no parent, it will have no newHeaderID as well
                }
                // if the current node does have a parent
                else
                {
                    // Find the parent. Search for x, where x.ID = the current node's parentID
                    ItemNode parent = Array.Find(inputTree, x => x.ID == currentNode.parentID);
                    // find the node that is currently below the parent to perform comparisons
                    ItemNode belowParent = inputTree[Array.IndexOf(inputTree, parent) + 1];

                    // update the newHeaderID now so we dont have to do it in every outcome
                    // this if/else might be unecessary? could just set to parent.NewID

                    // if the parent's newID has been updated, update headerID of current node
                    if (parent.NewID != currentNode.parentID)
                    {
                        currentNode.NewHeaderID = parent.NewID;
                    }
                    // if not, then the headerID is the same as the current parentID
                    else
                    {
                        currentNode.NewHeaderID = currentNode.parentID;
                    }

                    // now time for comparisons between belowParent and currentNode
                    // first check if they are equal
                    if (currentNode == belowParent)
                    {
                        // both are referring to the same node, it is in the correct spot so just update newID
                        currentNode.NewID = i + 1;
                    }
                    // they are not the same node, so compare parentIDs
                    else if (currentNode.parentID == belowParent.parentID)
                    {
                        // both have the same parent, so the one with the smaller ID goes on top
                        if (belowParent.ID < currentNode.ID)
                        {
                            // belowParent is not moved, current node is placed underneath
                            currentNode.NewID = Array.IndexOf(inputTree, belowParent) + 2;
                        }
                        else
                        {
                            // belowParent moves down, currentNode takes its place
                            currentNode.NewID = Array.IndexOf(inputTree, belowParent) + 1;
                            belowParent.NewID = currentNode.NewID + 1;
                        }
                    }
                    // they are not siblings. place the one with larger parentID on top to nest the children
                    else if (currentNode.parentID < belowParent.parentID)
                    {
                        // belowParent is not moved, current node is placed underneath
                        currentNode.NewID = Array.IndexOf(inputTree, belowParent) + 2;
                    }
                    else
                    {
                        // belowParent moves down, currentNode takes its place
                        currentNode.NewID = Array.IndexOf(inputTree, belowParent) + 1;
                        belowParent.NewID = currentNode.NewID + 1;
                    }
                }
            }
            //Array.Sort(inputTree, )
            return inputTree;
        }

        static void Main(string[] args)
        {
            // first create the tree we will be passing in
            List<ItemNode> itemList = new List<ItemNode>();

            // and now fill all indexes with sample data, yikes
            itemList.Add(new ItemNode("vzv", 1, -1, -1, -1));
            itemList.Add(new ItemNode("trc", 2, 1, -1, -1));
            itemList.Add(new ItemNode("hpc", 3, 1, -1, -1));
            itemList.Add(new ItemNode("hpd", 4, 1, -1, -1));
            itemList.Add(new ItemNode("vsr", 5, 1, -1, -1));
            itemList.Add(new ItemNode("nwb", 6, 2, -1, -1));
            itemList.Add(new ItemNode("msq", 7, 2, -1, -1));
            itemList.Add(new ItemNode("adp", 8, -1, -1, -1));
            itemList.Add(new ItemNode("gfx", 9, -1, -1, -1));
            itemList.Add(new ItemNode("xwg", 10, -1, -1, -1));
            itemList.Add(new ItemNode("hps", 11, 2, -1, -1));
            //itemList.Add(new ItemNode("zct", 12, 2, -1, -1));
            //itemList.Add(new ItemNode("4gd", 13, 7, -1, -1));

            ItemNode[] itemTree = itemList.ToArray();
            Console.WriteLine(itemTree.Length);

            ItemNode[] sortedTree = TreeNavigate(itemTree);
            for (int i = 0; i < itemTree.Length; i++)
            {
                Console.WriteLine(itemTree[i].name + " " + itemTree[i].ID + " " + itemTree[i].parentID + " " + itemTree[i].NewID + " " + itemTree[i].NewHeaderID);
            }

            string input = Console.ReadLine();
        }
    }
}
