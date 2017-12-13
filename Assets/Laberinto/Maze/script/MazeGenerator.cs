using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

	public int ancho, alto;
	public VisualCell visualCell;
	public Cell[,] celdas;

	private Vector2 posicionAletorioCelda;
	private VisualCell tempVisualCell;

	private List <CellAndRelativePosition> vecinoCeldas;


	void Start () {
		celdas = new Cell [ancho, alto];
		Init ();
	}
	void Init(){
		for(int i = 0; i < ancho; i++){
			for(int j = 0; j < alto; j++){
				celdas [i, j] = new Cell (false, false, false, false, false);
				celdas [i, j].xPos = i;
				celdas [i, j].zPos = j;
			}
		}
		RandomCell ();
		InitVisualCell ();
	}

	void RandomCell(){
		posicionAletorioCelda = new Vector2 ((int)Random.Range (0, ancho), (int)Random.Range (0, alto));
		GenerateMaze ((int)posicionAletorioCelda.x, (int)posicionAletorioCelda.y);
	}

	void GenerateMaze(int x, int y){
		Cell currentCell = celdas [x, y];
		vecinoCeldas = new List<CellAndRelativePosition>();
		if (currentCell._flag == true)
			return;
		currentCell._flag = true;

		//ESTE
		if (x + 1 < ancho && celdas [x + 1, y]._flag == false) {
			vecinoCeldas.Add (new CellAndRelativePosition(celdas[x + 1, y], CellAndRelativePosition.Direction.Este));
		}
		//SUR
		if (y + 1 < alto && celdas [x, y + 1]._flag == false) {
			vecinoCeldas.Add (new CellAndRelativePosition(celdas[x, y + 1], CellAndRelativePosition.Direction.Sur));
		}
		//OESTE
		if (x - 1 >= 0 && celdas [x - 1, y]._flag == false) {
			vecinoCeldas.Add (new CellAndRelativePosition(celdas[x - 1, y], CellAndRelativePosition.Direction.Oeste));
		}
		//NORTE
		if (y - 1 >= 0 && celdas [x, y - 1]._flag == false) {
			vecinoCeldas.Add (new CellAndRelativePosition(celdas[x, y - 1], CellAndRelativePosition.Direction.Norte));
		}

		if (vecinoCeldas.Count == 0)
			return;
		vecinoCeldas.Shuffle();

		foreach(CellAndRelativePosition selectedcell in vecinoCeldas){
			if (selectedcell.direction == CellAndRelativePosition.Direction.Este) {
				if (selectedcell.cell._flag)
					continue;
				currentCell._este = true;
				selectedcell.cell._oeste = true;
				GenerateMaze (x + 1, y);

			} else {
				if (selectedcell.direction == CellAndRelativePosition.Direction.Sur) {
					if (selectedcell.cell._flag)
						continue;
					currentCell._sur = true;
					selectedcell.cell._norte = true;
					GenerateMaze (x, y + 1);

				} else {
					if (selectedcell.direction == CellAndRelativePosition.Direction.Oeste) {
						if (selectedcell.cell._flag)
							continue;
						currentCell._oeste = true;
						selectedcell.cell._este = true;
						GenerateMaze (x - 1, y);

					} else {
						if (selectedcell.direction == CellAndRelativePosition.Direction.Norte) {
							if (selectedcell.cell._flag)
								continue;
							currentCell._sur = true;
							selectedcell.cell._norte = true;
							GenerateMaze (x, y - 1);

						}
					}
				}
				
			}
			

		}


	}
	void InitVisualCell(){
		foreach(Cell cell in celdas){
			tempVisualCell = Instantiate (visualCell,  new Vector3(cell.xPos*3, 0, alto*3f - cell.zPos*3), Quaternion.identity) as VisualCell;
			tempVisualCell.transform.parent = transform;
			tempVisualCell.norte.gameObject.SetActive (!cell._norte);
			tempVisualCell.sur.gameObject.SetActive (!cell._sur);
			tempVisualCell.este.gameObject.SetActive (!cell._este);
			tempVisualCell.oeste.gameObject.SetActive (!cell._oeste);

			tempVisualCell.transform.name = cell.xPos.ToString() + "_" + cell.zPos.ToString();
		}
	}
}
