using System;
using System.Collections.Generic;
using System.IO;

namespace LearnImmutable
{
    public class DirectoryTreeBuilder
    {
        public class TreeNode
        {
            public string Name { get; }
            public List<TreeNode> Children { get; } = new List<TreeNode>();

            public TreeNode(string name)
            {
                Name = name;
            }
        }

            public TreeNode BuildTree(string rootDirectory, string endpoint)
            {
                if (!Directory.Exists(rootDirectory))
                {
                    throw new DirectoryNotFoundException($"Directory not found: {rootDirectory}");
                }

                return BuildTreeRecursive(rootDirectory, endpoint);
            }

            private TreeNode BuildTreeRecursive(string directory, string endpoint)
            {
                var currentNode = new TreeNode(Path.GetFileName(directory));

                foreach (var subDirectory in Directory.GetDirectories(directory))
                {
                    if (subDirectory == endpoint)
                    {
                        continue;
                    }

                    var childNode = BuildTreeRecursive(subDirectory, endpoint);
                    currentNode.Children.Add(childNode);
                }
                return currentNode;
            }
        }

}
