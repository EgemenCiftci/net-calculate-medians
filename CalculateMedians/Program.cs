/*|||||||||||||||||||||||
||||  Egemen Ciftci  ||||
|||||||||||||||||||||||*/
double[] array = new double[] { 5, 2, 1, 4, 3 };
IEnumerable<double> medians = CalculateMedians(array);
Console.WriteLine(string.Join(" ", medians));

static IEnumerable<double> CalculateMedians(IEnumerable<double> input)
{
    if (input == null)
    {
        throw new ArgumentNullException("input is null");
    }

    // Declare two min heaps
    PriorityQueue<double, double> smaller = new(); // The values of this priority queue will be multiplied by -1 to convert it to a max heap.
    PriorityQueue<double, double> greater = new();

    foreach (double item in input)
    {
        double value = -item;
        value = -smaller.EnqueueDequeue(value, value);

        if (greater.Count == smaller.Count)
        {
            value = -greater.EnqueueDequeue(value, value);
            smaller.Enqueue(value, value);
        }
        else
        {
            greater.Enqueue(value, value);
        }

        yield return greater.Count == smaller.Count ? (greater.Peek() - smaller.Peek()) / 2 : -smaller.Peek();
    }
}