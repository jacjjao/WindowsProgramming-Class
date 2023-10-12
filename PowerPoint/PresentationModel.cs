using System;

namespace PowerPoint
{
	public class PresentationModel
	{
		public enum ShapeType
		{
			None,
			Circle,
			Line,
			Rectangle
		}

		public ShapeType SelectedShapeType
		{
			set;
			get;
		}

		public Model TheModel
        {
			get;
        }
		public PresentationModel(Model model)
		{
			SelectedShapeType = ShapeType.None;
			TheModel = model;
		}
	}
}