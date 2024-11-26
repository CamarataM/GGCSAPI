using Godot;
using System.Text;

namespace GGCSAPI {
	public static class Nodes {
		private const char NODE_PATH_SEPARATOR_CHARACTER = '/';

		public static Node GetRootNode() {
			return ((SceneTree) Engine.GetMainLoop()).CurrentScene;
		}

		public static Node GetRootNode(this Node node) {
			return node.GetTree().Root.GetChild(0);
		}

		public static NodePath GetParentPath(this NodePath nodePath, bool absolutePath = true) {
			var pathStringBuilder = new StringBuilder();
			if (absolutePath) {
				// Need to prefix for absolute paths.
				pathStringBuilder.Append(NODE_PATH_SEPARATOR_CHARACTER);
			}

			for (int i = 0; i < nodePath.GetNameCount() - 1; i++) {
				pathStringBuilder.Append(nodePath.GetName(i));
				pathStringBuilder.Append(NODE_PATH_SEPARATOR_CHARACTER);
			}

			return new NodePath(pathStringBuilder.ToString());
		}

		public static NodePath AppendPath(this NodePath nodePath, string appendPath) {
			string finalNodePath = nodePath.ToString();
			finalNodePath = finalNodePath + (finalNodePath[finalNodePath.Length - 1] == NODE_PATH_SEPARATOR_CHARACTER ? "" : NODE_PATH_SEPARATOR_CHARACTER) + appendPath;

			return new NodePath(finalNodePath);
		}

		public static Vector3 GetDirection(this Node3D node) {
			return -node.GlobalTransform.Basis.Z;
		}

		// Returns the parent node as well as its children in breadth-first search order.
		public static List<Node> GetChildrenNodes(this Node node, bool includeParent = true) {
			var nodes = new List<Node>();

			var queue = new Queue<Node>();
			queue.Enqueue(node);
			while (queue.Count > 0) {
				var stackNode = queue.Dequeue();

				// If we do not need to include the parent, don't add the first node added to the stack (the parent), then set 'includeParent' to true.
				if (!includeParent) {
					includeParent = true;
				} else {
					nodes.Add(stackNode);
				}

				foreach (var childNode in stackNode.GetChildren()) {
					queue.Enqueue(childNode);
				}
			}

			return nodes;
		}

		public static Node? GetChildAtIndex(this Node node, params int[] indices) {
			return GetChildAtIndex<Node>(node: node, indices: indices);
		}

		public static T? GetChildAtIndex<T>(this Node node, params int[] indices) where T : Node {
			Node currentNode = node;

			foreach (int index in indices) {
				if (currentNode == null) {
					return null;
				}

				currentNode = currentNode.GetChildOrNull<Node>(index);
			}

			try {
				return (T) currentNode;
			} catch (Exception) {
				return null;
			}
		}

		public static int GetBoneIDByName(this Skeleton3D skeleton3D, string boneName) {
			for (int i = 0; i < skeleton3D.GetBoneCount(); i++) {
				var skeletonBoneName = skeleton3D.GetBoneName(i);
				if (skeletonBoneName.Equals(boneName)) {
					return i;
				}
			}

			return -1;
		}

		public static void ClearChildrenNodes(this Node node, bool includeInternal = false) {
			foreach (var child in node.GetChildren(includeInternal: includeInternal)) {
				node.RemoveChild(child);
			}
		}

		public static void CopyProperty(Node fromNode, Node toNode, StringName propertyName) {
			toNode.Set(propertyName, fromNode.Get(propertyName));
		}

		public static void CopyPropertyTo(this Node fromNode, Node toNode, StringName propertyName) {
			Nodes.CopyProperty(fromNode: fromNode, toNode: toNode, propertyName: propertyName);
		}
	}
}
