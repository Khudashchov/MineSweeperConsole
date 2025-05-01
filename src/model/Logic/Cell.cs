public class Cell
{
    private bool _opened = false;
    private bool _mine = false;
    private int _CellValue = 0;

    public int CellValue{
        get{
            if(_mine)
            {
                return '#';
            }
            return _CellValue;
        }
        set{
            if(value > 5 || value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    public bool IsOpen()
    {
        return _opened;
    }
}