using System.Collections;
//Для того чтобы наш обьект мог работать с foreach нам нужно реализвать следующее
var person = new Person();

foreach (var item in person)
{
    Console.WriteLine((string)item);
}

//Чтобы объект класса мог взаимодействовать с конструкцией foreach,
//он должен поддерживать интерфейс IEnumerable.
//Это требуется для того, чтобы foreach знал, как получить элементы из коллекции по одному.
//Интерфейс IEnumerable требует наличие метода GetEnumerator()
//,который возвращает обьект который реализует интерфейс IEnumerator
//с методами MoveNext(),Reset() и свойством Current
public class Person : IEnumerable
{
    private string [] _names = { "Darya", "Anna", "Vlad"};
    public IEnumerator GetEnumerator()
    {
        return new Enumerator(_names);
    }
}

//Класс который реализует интерфейс IEnumerator 
public class Enumerator : IEnumerator
{
    private string[] _names;
    //Укзазатель с помощью которого будем двигаться по массиву 
    private int _position = -1;

    public Enumerator(string[] names)
    {
        _names = names;
    }
    //Метод который двигает указатель на один шаг вперед
    //И проверяет чтобы мы не вышли за пределы массива
    public bool MoveNext()
    {
        if (_position < _names.Length-1)
        {
            _position++;
        }
        else
        {
             return false;
        }

        return true;
    }

    //Свойсто Current возвращает текущий обьект
    public object Current
    {
        get
        {
            if (_position == -1 || _position >= _names.Length)
            {
                throw new ArgumentException();
            }
            return _names[_position];
        }
    }

    //Метод Reset сбрасывает указатель на начальное место после того как мы переберем все элементы 
    public void Reset()
    {
        _position = -1;
    }
}