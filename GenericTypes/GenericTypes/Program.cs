List<int> numbers = new List<int> { 1, 3, 1, 2, 41 };
List<string> words = new List<string> { "aaa", "bbb" };
List<DateTime> dates = new List<DateTime> { DateTime.Now, new DateTime(2025, 5, 30) };


public class IntList
{
    private int[] _items = new int[4];
    private int _size = 0;

    public void Add(int item)
    {
        if(_size >= _items.Length)
        {
            int[] newItems = new int[_items.Length * 2];

            for(int i = 0; i < _items.Length; i++ )
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }
        _items[_size] = item;
        ++_size;
    }

}