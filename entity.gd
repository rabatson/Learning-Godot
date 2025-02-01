extends CharacterBody2D
class_name Entity

@export var max_health: int = 100
@export var health: int = max_health
@export var max_stamina: int = 100
@export var stamina: int = max_stamina
@export var entity_name: String = "Entity Unnamed"

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass
