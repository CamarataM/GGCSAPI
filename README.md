# GGCSAPI

**GGCSAPI** (General Godot C# API) is a C# class library which provides utility methods for the [Godot](https://github.com/godotengine/godot) game engine.

This software is licensed under the [MIT](https://opensource.org/license/MIT) license.

## Usage
To use GGCSAPI in your project, put `using GGCSAPI;` at the top of your file, then call any of the various utility methods using `GGCSAPI.Class[.Sub-Function]`.

Examples:
```csharp
using GGCSAPI;

// Get root Node of scene.
GGCSAPI.Nodes.GetRootNode();

// Get forward direction of 3D Node.
GGCSAPI.Nodes.GetDirection(Node3D node);

// Recursively get children of Node.
GGCSAPI.Nodes.GetChildrenNodes(Node node);

// Remove all children Nodes.
GGCSAPI.Nodes.ClearChildrenNodes(Node node);

// Create a popup menu with various click actions.
var filePopupMenuBuilder = new GGCSAPI.PopupMenuBuilder("File")
			.AddItem("New File", (long _) => { 
				// Create new file. 
			})
			.AddItem("Close File", (long _) => {
				// Close current file.
			});
			.AddItem("Exit", (long _) => {
				GetTree().Quit();
			});
```

## Contributing
All contributions are welcome, although please not that functionality outside the scope of Godot utility should preferably be put into a different project.

## License
This software is licensed under the [MIT](https://opensource.org/license/MIT) license.

Copyright information generation is created using [CopyrightGenerator](https://github.com/CamarataM/CopyrightGenerator).