var file = File.ReadAllLines("../aoc_day_10");

var list = file.Select(x =>
{
    Console.WriteLine(x);
    return x;
}).ToList();


var maxHeap = new PriorityQueue<int>();

maxHeap.Enqueue(5);
maxHeap.Enqueue(4);
maxHeap.Enqueue(3);
maxHeap.Enqueue(2);
maxHeap.Enqueue(9);
maxHeap.Enqueue(8);
maxHeap.Enqueue(7);
maxHeap.Enqueue(6);

maxHeap.Enqueue(1);

// Get the peak element (i.e., the smallest element)
int peakElement = maxHeap.Peek();

// Print the peak element
Console.WriteLine("Max Peak element: " + peakElement);


var minHeap = new PriorityQueue<int>(false);

minHeap.Enqueue(5);
minHeap.Enqueue(4);
minHeap.Enqueue(3);
minHeap.Enqueue(20);
minHeap.Enqueue(380);

Console.WriteLine("Min Peak element: " + minHeap.Peek());


string t = string.Empty;

t = "YOOOOOO";

Console.WriteLine(t);

class PriorityQueue<T>(bool isMaxHeap = true) where T : IComparable<T>
{
    private List<T> heap = [];


    public int Count => this.heap.Count;

    public void Enqueue(T item)
    {
        this.heap.Add(item);
        this.BubbleUp(this.heap.Count - 1);
    }

    public T Dequeue()
    {
        T item = this.heap[0];
        int lastIndex = this.heap.Count - 1;
        this.heap[0] = this.heap[lastIndex];
        this.heap.RemoveAt(lastIndex);
        this.BubbleDown(0);
        return item;
    }

    public T Peek() => this.heap[0];

    private void BubbleUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (isMaxHeap)
            {
                if (this.heap[parentIndex].CompareTo(this.heap[index]) >= 0)
                    break;
            }
            else
            {
                if (this.heap[parentIndex].CompareTo(this.heap[index]) <= 0)
                    break;
            }
            Swap(parentIndex, index);
            index = parentIndex;
        }
    }

    private void BubbleDown(int index)
    {
        while (index < this.heap.Count)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            if (!isMaxHeap)
            {
                int smallestchildIndex = index;
                if (leftChildIndex < this.heap.Count && this.heap[leftChildIndex].CompareTo(this.heap[smallestchildIndex]) < 0)
                    smallestchildIndex = leftChildIndex;
                if (rightChildIndex < this.heap.Count && this.heap[rightChildIndex].CompareTo(this.heap[smallestchildIndex]) < 0)
                    smallestchildIndex = rightChildIndex;
                if (smallestchildIndex == index)
                    break;

                Swap(smallestchildIndex, index);
                index = smallestchildIndex;
                return;
            }

            int largestChildIndex = index;
            if (leftChildIndex < this.heap.Count && this.heap[leftChildIndex].CompareTo(this.heap[largestChildIndex]) > 0)
                largestChildIndex = leftChildIndex;
            if (rightChildIndex < this.heap.Count && this.heap[rightChildIndex].CompareTo(this.heap[largestChildIndex]) > 0)
                largestChildIndex = rightChildIndex;
            if (largestChildIndex == index)
                break;

            Swap(largestChildIndex, index);
            index = largestChildIndex;
        }
    }

    private void Swap(int i, int j) =>
        (this.heap[j], this.heap[i]) = (this.heap[i], this.heap[j]);
}