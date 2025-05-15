namespace MineSweeper.Model.Logic.Round;

public class Cell
{
    private bool _opened = false;
    private bool _mine = false;
    private int _cellValue;

    public int CellValue{
        get{
            if(_mine)
            {
                return 35;
            }
            return _cellValue;
        }
        set{
            if(value > 10 || value < 0)
            {
                throw new ArgumentOutOfRangeException();
            } else
            {
                _cellValue = value;
            }
        }
    }

    public bool IsOpen() => _opened;

    public void Open() => _opened = true;

    public void SetMine() => _mine = true;

    public bool IsMine() => _mine;

    public bool IsEmpty() => _cellValue == 0 && !_mine;

    public void PrintCell()
    {
        if(IsOpen())
        {
            if(IsMine())
            {
                Console.Write('#');
            } else if (IsEmpty())
            {
                Console.Write(' ');
            } else
            {
                Console.Write(CellValue);
            }
        } else
        {
            Console.Write(' ');
        }
    }
}