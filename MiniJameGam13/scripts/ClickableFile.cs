using Godot;
using System;

public class ClickableFile : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    [Export]
    public string name = "file";
    [Export]
    public bool locked = false;
    [Export]
    public bool deletable = true;
    [Export]
    public Texture texture;

    [Signal]
    public delegate void OnClick();

    private Label label;
    private Sprite background;
    private Sprite sprite;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.label = GetNode<Label>("Label");
        this.label.Text = name;
        background = GetNode<Sprite>("Background");
        sprite = GetNode<Sprite>("Sprite");
        sprite.Texture = texture;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    public void OnMouseEntered() {
        background.Show();
    }

    public void OnMouseExited() {
        background.Hide();
    }

    public void OnInputEvent(Node node, InputEvent @event, int idx) {
        if (@event.IsActionPressed("right_click")) {
            GD.Print("cc");
        } else if (@event.IsActionPressed("click")) {
            EmitSignal("OnClick");
            GD.Print("oui");
        }
    }
}
