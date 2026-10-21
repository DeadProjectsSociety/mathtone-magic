using System.Collections;

namespace Mathtone.Sdk.Graphs {
	public class Tree<T> : IEnumerable<Tree<T>> {

		readonly List<Tree<T>> _children = new();
		Tree<T>? _parent;

		public T? Value { get; set; }
		public Tree<T>? Parent { get => _parent; set => SetParent(value); }
		public Tree<T> this[int index] => _children[index];

		public Tree() : this(default) { }

		public Tree(T? value) {
			Value = value;
		}

		public void SetParent(Tree<T>? parent) {
			for (var ancestor = parent; ancestor != null; ancestor = ancestor.Parent) {
				if (ReferenceEquals(ancestor, this)) {
					throw new ArgumentException("A node cannot be parented to itself or one of its descendants.", nameof(parent));
				}
			}

			if (_parent != null) {
				_parent._children.Remove(this);
			}
			_parent = parent;
			_parent?._children.Add(this);
		}

		public void Add(Tree<T> child) {
			child.SetParent(this);
		}

		public IEnumerable<Tree<T>> WithAncestors => Ancestors.Prepend(this);
		public IEnumerable<Tree<T>> Ancestors {
			get {
				var p = Parent;
				while (p != null) {
					yield return p;
					p = p.Parent;
				}
			}
		}
		public IEnumerable<Tree<T>> WithDescendents => Descendents.Prepend(this);
		public IEnumerable<Tree<T>> Descendents {
			get {
				foreach (var c in this) {
					yield return c;
					foreach (var d in c.Descendents) {
						yield return d;
					}
				}
			}
		}

		public IEnumerator<Tree<T>> GetEnumerator() => _children.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}