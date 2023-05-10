using System.Collections.Generic;
using System.Numerics;
public class World {
	readonly char[] sublistKeys;

	readonly List<Entity> allEntities = new List<Entity>();

	readonly Dictionary<char, List<Entity>> entitySublists = new Dictionary<char, List<Entity>>();

	public char[] layers = new char[0];

	public World (char[] sublistKeys) {
		this.sublistKeys = sublistKeys;
		for (int i = 0; i < sublistKeys.Length; i++) {
			entitySublists.Add(sublistKeys[i], new List<Entity>());
		}
	}

	public void Update (float dt) {
		Entity.UpdateAll(allEntities, this, dt);

		if (Entity.CleanList(allEntities)) {
			for (int i = 0; i < sublistKeys.Length; i++) {
				Entity.CleanList(entitySublists[sublistKeys[i]]);
			}
		}
	}

	public void Draw () {
		for (int l = layers.Length - 1; l >= 0; l--) {
			Entity.DrawAll(entitySublists[layers[l]]);
		}
	}

	public void Add (Entity entity) {
		entity.OnAdd(this);
		allEntities.Add(entity);
	}

	public void Add (Entity entity, Vector2 position) {
		entity.position = position;
		Add(entity);
	}

	public List<Entity> GetSublist (char c) {
		return entitySublists[c];
	}

	public List<Entity> GetSublist (int i) {
		return GetSublist(sublistKeys[i]);
	}
}