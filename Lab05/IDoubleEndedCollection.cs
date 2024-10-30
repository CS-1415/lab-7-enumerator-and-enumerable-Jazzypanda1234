namespace Lab05;

public interface IDoubleEndedCollection<T>
{
    int Length { get; set; }
    void AddLast(T value); void AddFirst(T value);
    void RemoveFirst(); void RemoveLast(); void ReverseList();
}

public class DoublyLinkedList<T> : IDoubleEndedCollection<T>
{
    private DNode<T>? _head = null;
    private DNode<T>? _tail = null;
    public int Length { get; set; } = 0;
    public DoublyLinkedList(DNode<T>? _head, DNode<T>? _tail, int Length)
    {
        this._head = _head;
        this._tail = _tail;
        this.Length = Length;
    }

    // TODO: implement the methods of the interface

    public void AddLast(T value)
    {
        //    create a new node with the new value
        DNode<T> dNode = new DNode<T>(value, null, null);
        //    if the list is empty:
        if (_head == null)
        {
        //  set head and tail to both point to that new node
            _head = dNode;
            _tail = dNode;
        }
        //    otherwise:
        else
        {
        //        set tail's next to point to the new node
            _tail.Next = dNode;
        //        set the new node's previous to point to tail
            dNode.Previous = _tail;
        //        set tail to point to the new node
            _tail = dNode;
        }
        //    increment the length
        Length++;
    }

    public void RemoveLast()
    {
        //    if the list only has one item:
        if (_tail.Previous == null)
        {
        //        set head and tail both to null
            _head = null;
            _tail = null;
        }
        //    otherwise:
        else 
        {
        //        get the second to last node and set its next to null
            _tail.Previous.Next = null;
        }
        //    decrement the length
        Length--;
    }
    public void AddFirst(T value)
    {
        //    create a new node with the new value
        DNode<T> dNode = new DNode<T>(value, null, null);
        //    if the list is empty:
        if (_head == null)
        {
        //  set head and tail to both point to that new node
            _head = dNode;
            _tail = dNode;
        }
        //    otherwise:
        else
        {
        //        set head's next to point to the new node
            _head.Previous = dNode;
        //        set the new node's previous to point to head
            dNode.Next = _head;
        //        set head to point to the new node
            _head = dNode;
        }
        //    increment the length
        Length++;
    }

    public void RemoveFirst()
    {
        //    if the list only has one item:
        if (_head == _tail)
        {
        //        set head and tail both to null
            _head = null;
            _tail = null;
        }
        //    otherwise:
        else 
        {
        //        get the second to last node and set its previous to null
            _head.Next.Previous = null;
        }
        //    decrement the length
        Length--;
    }

    public void ReverseList()
    {
        DNode<T>? current = null;
        DNode<T>? temp_head = null;
        DNode<T>? temp_tail = null;
        current = _tail;
        while (current != null)
        {
            DNode<T> dNode = new DNode<T>(current.Value, null, null);
            //    if the list is empty:
            if (temp_head == null)
            {
                //  set head and tail to both point to that new node
                temp_head = dNode;
                temp_tail = dNode;
            }
            //    otherwise:
            else
            {
                //        set head's next to point to the new node
                temp_tail.Previous = dNode;
                //        set the new node's previous to point to head
                dNode.Next = temp_tail;
                //        set head to point to the new node
                temp_tail = dNode;
            }
            current = current.Previous;
        }
        _head = temp_head;
        _tail = temp_tail;
    }
}