public class CellAndRelativePosition {
	public Cell cell;
	public Direction direction;

	public enum Direction{
		Norte,
		Sur,
		Este,
		Oeste
	}

	public CellAndRelativePosition (Cell cell, Direction direction){
		this.cell = cell;
		this.direction = direction;
	}
}
