using System.Numerics;
public abstract class Entity: Collider {
	bool shouldRemove = false;
	public bool ShouldRemove => shouldRemove;

	public EntityRenderer? renderer = null;

	public Entity (): base (Vector2.Zero, Vector2.One) {}
	public Entity (Vector2 size): base (Vector2.Zero, size) {}

	// callbacks
	public abstract void OnAdd (World world);
	public virtual void Update (World world, float dt) {}
	public virtual bool Message (char c, Vector2 input) {return false;}

	// drawing the object
	public void Draw () {
		if (renderer != null) {
			renderer.Draw(this);
		}
	}

	// Destroys the entity 
	public void Destroy () {
		shouldRemove = true;
	}

	// Updates every entity in the list
	public static void UpdateAll (List<Entity> entities, World world, float dt) {
		for (int i = 0; i < entities.Count; i++) {
			entities[i].Update(world, dt);
		}
	}

	// Draws every entity in the list
	public static void DrawAll (List<Entity> entities)  {
		for (int i = 0; i < entities.Count; i++) {
			entities[i].Draw();
		}
	}

	// removes every entity that is marked for removal. Returns whether an object was removed
	public static bool CleanList (List<Entity> entities) {
		bool objRemoved = false;
		for (int i = entities.Count - 1; i >= 0; i--) {
			if (entities[i].shouldRemove){
				entities.RemoveAt(i);
				objRemoved = true;
			}
		}

		return objRemoved;
	}
}

public abstract class EntityRenderer {
	public Vector2 size = Vector2.One;

	public abstract void Draw (Entity entity);
}