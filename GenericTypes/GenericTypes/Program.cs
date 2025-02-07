List<int> numbers = new List<int> { 1, 3, 1, 2, 41 };
List<string> words = new List<string> { "aaa", "bbb" };
List<DateTime> dates = new List<DateTime> { DateTime.Now, new DateTime(2025, 5, 30) };


GenericList<int> list = new GenericList<int>();
GenericList<string> list2 = new GenericList<string>();

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

list2.Add("aaa");
list2.Add("bbb");
list2.Add("ccc");
list2.Add("ddd");
list2.Add("eee");

foreach(string i in list2.GetList())
{
    Console.WriteLine(i);
}

Console.WriteLine($"Number on index 2: {list2.GetAtIndex(2)}");

list2.RemoveAt(2);

Console.WriteLine($"Number on index 2: {list2.GetAtIndex(2)}");

foreach (string i in list2.GetList())
{
    Console.WriteLine(i);
}

Console.ReadKey();

public class GenericList<T> // We can have multiple type parameters in there, ie, <TValue, TOtherValue>
{
    private T[] _items = new T[4];
    private int _size = 0;

    public void Add(T item)
    {
        if(_size >= _items.Length)
        {
            T[] newItems = new T[_items.Length * 2];

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
        if(index < 0 && index > _items.Length)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the bonds of the list.");
        }

        --_size;

        for(int i = index; i < _size; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[_size] = default;
    }

    public T[] GetList()
    {
        return _items;
    }

    public T GetAtIndex(int index)
    {
        if (index < 0 && index > _items.Length)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the bonds of the list.");
        }

        return _items[index];
    }
}