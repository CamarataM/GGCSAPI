using Godot;

namespace GGCSAPI {
	public class PopupMenuBuilder {
		public PopupMenu PopupMenu;
		public long GlobalPopupMenuID = 0;
		public Dictionary<long, List<Action<long>>> GlobalIDToPressedFunctionListDictionary = new Dictionary<long, List<Action<long>>>();

		public PopupMenuBuilder(string name) {
			PopupMenu = new PopupMenu();
			PopupMenu.Name = name;

			PopupMenu.IdPressed += (long id) => {
				if (GlobalIDToPressedFunctionListDictionary.ContainsKey(id)) {
					foreach (var function in GlobalIDToPressedFunctionListDictionary[id]) {
						function.Invoke(id);
					}
				}
			};
		}

		public PopupMenuBuilder AddItem(string label, params Action<long>[] actions) {
			long currentID = GlobalPopupMenuID;

			PopupMenu.AddItem(label, (int) currentID);
			if (actions != null && actions.Length > 0) {
				if (!GlobalIDToPressedFunctionListDictionary.ContainsKey(currentID)) {
					GlobalIDToPressedFunctionListDictionary.Add(currentID, new List<Action<long>>());
				}

				foreach (var action in actions) {
					GlobalIDToPressedFunctionListDictionary[currentID].Add(action);
				}
			}

			GlobalPopupMenuID += 1;

			return this;
		}

		public PopupMenuBuilder AddSeparator(string label = "") {
			PopupMenu.AddSeparator(label);
			return this;
		}

		public PopupMenu Build() {
			return PopupMenu;
		}
	}
}