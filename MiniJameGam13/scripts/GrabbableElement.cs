using Godot;
using System;

public class GrabbableElement : RigidBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    public Material outlineMaterial;
    [Export]
    public float projectionScale = 50;

    private Sprite sprite;

    private bool grabbed;
    private bool t_minus_1_grabbed;
    private Vector2 grabbed_offset;
    private Vector2 projection_dir;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
       
        sprite = GetNode<Sprite>("Sprite");
        Connect("input_event", this, "OnInputEvent");
        Connect("mouse_entered", this, "OnMouseEntered");
        Connect("mouse_exited", this, "OnMouseExited");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (Input.IsMouseButtonPressed((int) ButtonList.Left) && grabbed) {
            Position = GetGlobalMousePosition() + grabbed_offset;
            LookAt(GetGlobalMousePosition());
        }
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        
        if (Input.IsMouseButtonPressed((int) ButtonList.Left) && grabbed) {
            LinearVelocity = Vector2.Zero;
        } else {
            grabbed = false;
        }
        if (!grabbed && t_minus_1_grabbed) {
            LinearVelocity = projection_dir;
        }
        t_minus_1_grabbed = grabbed;
    }

    public void OnInputEvent(Node node, InputEvent @event, int idx) {
        if (@event is InputEventMouseButton) {
            grabbed = ((InputEventMouseButton) @event).Pressed;
            grabbed_offset = Position - GetGlobalMousePosition();
        } else if (@event is InputEventMouseMotion) {
            projection_dir = ((InputEventMouseMotion) @event).Relative*projectionScale;
        }
    }

    public void OnMouseEntered() {
        sprite.Material = outlineMaterial;
    }

    public void OnMouseExited() {
        sprite.Material = null;
    }
}
