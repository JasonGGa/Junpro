public class Cell{
	public bool _este, _oeste, _norte, _sur;
	public bool _flag;
	public int xPos, zPos;

	public Cell (bool este, bool oeste, bool norte, bool sur, bool flag){
		this._este = este;
		this._oeste = oeste;
		this._norte = norte;
		this._sur = sur;
	}
}
