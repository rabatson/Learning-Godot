using Godot;

public partial class HUD : Control
{
	private double MaxHealth { get; set; }
	private double Health { get; set; }
	private double MaxStamina { get; set; }
	private double Stamina { get; set; }


	private ColorRect HealthBar;
	private Label HealthLabel;
	private ColorRect StaminaBar;
	private Label StaminaLabel;

	public override void _Ready()
	{
		Player player = GetNode<Player>("../Player");
		player.SetHealth += OnSetHealth;
		player.SetMaxHealth += OnSetMaxHealth;
		player.SetStamina += OnSetStamina;
		player.SetMaxStamina += OnSetMaxStamina;
		HealthBar = GetNode<ColorRect>("../HUD/HealthBar");
		HealthLabel = GetNode<Label>("../HUD/HealthBar/HealthLabel");
		StaminaBar = GetNode<ColorRect>("../HUD/StaminaBar");
		StaminaLabel = GetNode<Label>("../HUD/StaminaBar/StaminaLabel");
	}

	public override void _Process(double _delta)
	{
		if (HealthLabel != null)
		{
			HealthLabel.Text = $"Health {Health} / {MaxHealth}";
		}
		if (StaminaLabel != null)
		{
			StaminaLabel.Text = $"Stamina {Stamina} / {MaxStamina}";
		}
	}

	private void OnSetHealth(double value)
	{
		GD.PrintErr("it hit it");
		Health = value;

		HealthLabel.Text = $"Health {Health} / {MaxHealth}";
	}
	private void OnSetMaxHealth(double value)
	{
		HealthLabel.Text = $"Health {Health} / {MaxHealth}";
	}
	private void OnSetStamina(double value)
	{
		Stamina = value;
	}
	private void OnSetMaxStamina(double value)
	{
		MaxStamina = value;
	}

}
