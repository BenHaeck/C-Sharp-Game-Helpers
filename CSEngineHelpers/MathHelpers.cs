using System.Numerics;



public class MathHelpers {
	public static (Vector2, float) FitCanvas (Vector2 canvasSize, Vector2 windowSize) {
		if (canvasSize == Vector2.Zero || windowSize == Vector2.Zero)
			return (Vector2.Zero, 1);
		float canvAspR = canvasSize.Y / canvasSize.X;
		float winAspR = windowSize.Y / windowSize.X;
		Vector2 position = Vector2.Zero;
		float scale = 1;
		if (canvAspR < winAspR){
			scale = windowSize.X / canvasSize.X;
			position.Y = (windowSize.Y - canvasSize.Y * scale)*0.5f;
			
		} else {
			scale =  windowSize.Y / canvasSize.Y;
			position.X = (windowSize.X - canvasSize.X * scale)*0.5f;

		}
		return (position, scale);
	}

	public static Vector2 ScreenToCanvas ((Vector2 pos, float scale) canvasVals, Vector2 point) {
		return (point - canvasVals.pos) / canvasVals.scale;
	}
}
