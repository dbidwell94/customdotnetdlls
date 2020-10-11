# customdotnetdlls
Custom data structures and util classes. Generic Binary Search Tree, custom IP Address class, etc.

You do NOT interact with TreeNode class directly. Simply insert the value you want to insert using the BinarySearchTree.Insert() method, and everything is handled
behind the scenes. 

Will (later) incorperate AVL auto balancing as well as deletion from the Tree.

To access number of items in the tree, use the BinarySearchTree.Count property. To get the height of the tree, use the GetHeight() mehthod.

Any item that goes into the BinarySearchTree MUST also implement the IComparable<T> interface.

## Ip Address class

This class takes in an *Ip V4* address as a string, and an optional Name parameter.

Modified date will update anytime the Name changes. 
