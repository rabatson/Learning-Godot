using Godot;

public partial class Player : Entity
{
	[Export]
	public float BASE_MOVE_SPEED { get; set; } = 150.0f;
	[Export]
	public float MoveSpeed { get; set; }
	[Export]
	public float RunSpeed { get; set; } = 250.0f;
	[Export]
	public bool AcceptInput { get; set; } = true;

	[Signal]
	public delegate void DebugVelocityEventHandler(Vector2 vector);
	[Signal]
	public delegate void DebugDirectionEventHandler(double angle);

	[Signal]
	public delegate void SetHealthEventHandler(double value);
	[Signal]
	public delegate void SetMaxHealthEventHandler(double value);
	[Signal]
	public delegate void SetStaminaEventHandler(double value);
	[Signal]
	public delegate void SetMaxStaminaEventHandler(double value);

	private RayCast2D EntityDetector;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MoveSpeed = BASE_MOVE_SPEED;
		EntityDetector = GetNode<RayCast2D>("EntityDetector");
		if (OS.IsDebugBuild())
		{
			EntityDetector.GetNode<Line2D>("EntityDetectorVisualization").Visible = true;
		}
		
		// these signals aren't getting called on _Ready - they don't appear to be connected until after the _Ready has already been called
		// todo: figure that out - it SHOULD work as this same logic existed in the gdscript variant
		EmitSignal(SignalName.SetHealth, Health);
		EmitSignal(SignalName.SetMaxHealth, Health);
		EmitSignal(SignalName.SetStamina, Health);
		EmitSignal(SignalName.SetMaxStamina, Health);

		// Set an arbitrary south direction for the debug ui
		EmitSignal(SignalName.DebugDirection, 1.5);
	}

	public override void _PhysicsProcess(double delta)
	{
		if (AcceptInput)
		{
			GetInput();
			MoveAndSlide();
		}
	}

	public void GetInput()
	{
		// Get input direction
		Vector2 input_direction = new Vector2(
			Input.GetAxis("move_left", "move_right"),
			Input.GetAxis("move_up", "move_down")
		);

		// Normalize input direction to prevent faster diagonal movement
		if (input_direction != Vector2.Zero)
		{
			input_direction = input_direction.Normalized();
		}

		// Speed up the movement for run, slow it down for walk
		if (Input.IsActionPressed("run"))
		{
			MoveSpeed = RunSpeed;
		}
		else
		{
			MoveSpeed = BASE_MOVE_SPEED;
		}

		// Set velocity based on input direction
		Velocity = input_direction * (float)MoveSpeed;
		EmitSignal(SignalName.DebugVelocity, Velocity);
		SetPlayerLookDirection(Velocity);
	}

	public void SetPlayerLookDirection(Vector2 vector)
	{
		if (vector != Vector2.Zero)
		{
			float angle = vector.Angle();
			EmitSignal(SignalName.DebugDirection, angle);
			// Set the raycast rotation to whatever direction it is
			EntityDetector.Rotation = angle;
		}
	}
}
