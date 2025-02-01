extends Control

@export var max_health: int = 100
@export var health: int = max_health
@export var max_stamina: int = 100
@export var stamina: int = max_stamina

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	$StaminaBar/StaminaLabel.text = "Stamina: " + str(stamina) + " / " + str(max_stamina)
	$HealthBar/HealthLabel.text = "Health: " + str(health) + " / " + str(max_health)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	$StaminaBar/StaminaLabel.text = "Stamina: " + str(stamina) + " / " + str(max_stamina)
	$HealthBar/HealthLabel.text = "Health: " + str(health) + " / " + str(max_health)

func _on_player_set_health(value: int) -> void:
	health = value


func _on_player_set_stamina(value: int) -> void:
	stamina = value


func _on_player_set_max_health(value: int) -> void:
	max_health = value

func _on_player_set_max_stamina(value: int) -> void:
	max_stamina = value
