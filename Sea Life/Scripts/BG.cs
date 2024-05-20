using Godot;

public partial class BG : ParallaxBackground
{
	private float scrollingSpeed = 200;

	public override void _Process(double delta)
	{
		ScrollOffset = new Vector2(ScrollOffset.X - scrollingSpeed * (float)delta, ScrollOffset.Y);
	}
}
