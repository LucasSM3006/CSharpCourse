List<int> numbers = new List<int> { 1, 3, 1, 2, 41 };
List<string> words = new List<string> { "aaa", "bbb" };
List<DateTime> dates = new List<DateTime> { DateTime.Now, new DateTime(2025, 5, 30) };

IntList list = new IntList();

list.Add(10);
list.Add(20);
list.Add(30);
list.Add(40);
list.Add(50);

foreach (int i in list.GetList())
{
    Console.WriteLine(i);
}

Console.WriteLine($"Number on index 2: {list.GetAtIndex(2)}");

list.RemoveAt(2);

Console.WriteLine($"Number on index 2: {list.GetAtIndex(2)}");

foreach(int i in list.GetList())
{
    Console.WriteLine(i);
}

Console.ReadKey();

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

    public void RemoveAt(int index)
    {
        if(index > 0 && index < _items.Length)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the bonds of the list.");
        }

        --_size;

        for(int i = index; i < _size; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[_size] = 0;
    }

    public int[] GetList()
    {
        return _items;
    }

    public int GetAtIndex(int index)
    {
        if (index > 0 && index < _items.Length)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the bonds of the list.");
        }

        return _items[index];
    }
}