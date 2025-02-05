using Godot;

public partial class DebugInfo : Control
{
#nullable enable
	private Label? velocityLabel;
	private Label? directionLabel;
#nullable disable
	public override void _Ready()
	{
		velocityLabel = GetNode<Label>("velocityDebug");
		directionLabel = GetNode<Label>("directionDebug");
		Player player = GetNode<Player>("../Player");
		player.DebugDirection += OnPlayerDebugDirection;
		player.DebugVelocity += OnPlayerDebugVelocity;
	}

	public void OnPlayerDebugVelocity(Vector2 velocity)
	{
		if (velocityLabel != null)
		{
			velocityLabel.Text = $"Velocity: {velocity}";
		}
	}

	public void OnPlayerDebugDirection(double angle)
	{
		if (velocityLabel != null)
		{
			string selectedDirection = "";
			if (-Mathf.Pi / 8 <= angle && angle < Mathf.Pi / 8)
			{
				selectedDirection = "E";
			}
			else if (angle >= Mathf.Pi / 8 && angle < 3 * Mathf.Pi / 8)
			{
				selectedDirection = "SE";
			}

			else if (angle >= 3 * Mathf.Pi / 8 && angle < 5 * Mathf.Pi / 8)
			{
				selectedDirection = "S";
			}
			else if (angle >= 5 * Mathf.Pi / 8 && angle < 7 * Mathf.Pi / 8)
			{
				selectedDirection = "SW";
			}
			else if (angle >= 7 * Mathf.Pi / 8 || angle < -7 * Mathf.Pi / 8)
			{
				selectedDirection = "W";
			}
			else if (angle >= -7 * Mathf.Pi / 8 && angle < -5 * Mathf.Pi / 8)
			{
				selectedDirection = "NW";
			}
			else if (angle >= -5 * Mathf.Pi / 8 && angle < -3 * Mathf.Pi / 8)
			{
				selectedDirection = "N";
			}
			else if (angle >= -3 * Mathf.Pi / 8 && angle < -Mathf.Pi / 8)
			{
				selectedDirection = "NE";
			}
			directionLabel.Text = $"Facing: {selectedDirection}";
		}
	}
}
