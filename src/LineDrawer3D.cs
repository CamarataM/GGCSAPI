using Godot;

namespace GGCSAPI {
	[GlobalClass]
	public partial class LineDrawer3D : MeshInstance3D {
		private StandardMaterial3D Material = new StandardMaterial3D();
		private ImmediateMesh ImmediateMesh;

		public LineDrawer3D(Node3D parentNode) {
			ArgumentNullException.ThrowIfNull(parentNode);

			this.ImmediateMesh = new ImmediateMesh();

			this.Material.NoDepthTest = true;
			this.Material.ShadingMode = BaseMaterial3D.ShadingModeEnum.Unshaded;
			this.Material.VertexColorUseAsAlbedo = true;
			this.Material.Transparency = BaseMaterial3D.TransparencyEnum.Alpha;

			this.MaterialOverride = Material;
			this.Mesh = ImmediateMesh;

			parentNode.AddChild(this);
		}

		public void DrawLine(Vector3 start, Vector3 end, Color color) {
			ImmediateMesh.SurfaceBegin(Mesh.PrimitiveType.Lines);
			ImmediateMesh.SurfaceSetColor(color);
			ImmediateMesh.SurfaceAddVertex(start);
			ImmediateMesh.SurfaceAddVertex(end);
			ImmediateMesh.SurfaceEnd();
		}

		public override void _Process(double delta) {
			ImmediateMesh.ClearSurfaces();
		}
	}
}
