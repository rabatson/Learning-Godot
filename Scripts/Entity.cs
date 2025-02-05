using Godot;

public partial class Entity : CharacterBody2D
{
	[Export]
	public double MaxHealth { get; set; } = 100;
	[Export]
	public double Health { get; set; }
	[Export]
	public double MaxStamina { get; set; } = 100;
	[Export]
	public double Stamina { get; set; }
#nullable enable
	[Export]
	public string? EntityName { get; set; }
#nullable disable

	public override void _Ready()
	{

	}

	public override void _PhysicsProcess(double delta)
	{

		// do nothing for now
	}
}
