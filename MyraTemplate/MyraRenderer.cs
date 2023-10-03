using Stride.Rendering;
using Stride.Graphics;
using Stride.Engine;
using Stride.Rendering.Compositing;
using Stride.Games;
using Stride.Core.Mathematics;
using RenderContext = Stride.Rendering.RenderContext;

using Myra;
using Myra.Graphics2D.UI;

namespace MyraTemplate;

public class MyraRenderer : SceneRendererBase
{

	private Desktop _desktop;

	// Declared public member fields and properties will show in the game studio
	protected override void InitializeCore()
	{
		base.InitializeCore();
		Services.AddService(this);
		// Initialization of the script.
		MyraEnvironment.Game = (Game)this.Services.GetService<IGame>();

		var grid = new Grid
		{
			RowSpacing = 8,
			ColumnSpacing = 8
		};

		grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
		grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
		grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
		grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

		var helloWorld = new Label
		{
			Id = "label",
			Text = "Hello, World!"
		};
		grid.Widgets.Add(helloWorld);

		// ComboBox
		var combo = new ComboBox
		{
			GridColumn = 1,
			GridRow = 0
		};

		combo.Items.Add(new ListItem("Red", Color.Red));
		combo.Items.Add(new ListItem("Green", Color.Green));
		combo.Items.Add(new ListItem("Blue", Color.Blue));
		grid.Widgets.Add(combo);

		// Button
		var button = new TextButton
		{
			GridColumn = 0,
			GridRow = 1,
			Text = "Show"
		};

		button.Click += (s, a) =>
		{
			var messageBox = Dialog.CreateMessageBox("Message", "Some message!");
			messageBox.ShowModal(_desktop);
		};

		grid.Widgets.Add(button);

		// Spin button
		var spinButton = new SpinButton
		{
			GridColumn = 1,
			GridRow = 1,
			Width = 100,
			Nullable = true
		};
		grid.Widgets.Add(spinButton);

		// Add it to the desktop
		_desktop = new Desktop();
		_desktop.Root = grid;
	}

	protected override void DrawCore(RenderContext context, RenderDrawContext drawContext)
	{
		// Clear depth buffer
		drawContext.CommandList.Clear(GraphicsDevice.Presenter.DepthStencilBuffer, DepthStencilClearOptions.DepthBuffer);

		// Render UI
		_desktop.Render();
	}
}
