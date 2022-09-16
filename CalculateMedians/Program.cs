  ///////////////////
 // Egemen Ciftci //
///////////////////
var array = new double[] { 5, 2, 1, 4, 3 };
var medians = CalculateMedians(array);
Console.WriteLine(string.Join(" ", medians));

static IEnumerable<double> CalculateMedians(IEnumerable<double> input)
{
    // Declare two min heaps
    var smaller = new PriorityQueue<double, double>();
    var greater = new PriorityQueue<double, double>();

    foreach (var item in input)
    {
        var value = -1 * item; // Multiply the value with -1 to use min heap as a max heap
        value = -1 * smaller.EnqueueDequeue(value, value);

        if (greater.Count == smaller.Count)
        {
            value = -1 * greater.EnqueueDequeue(value, value);
            smaller.Enqueue(value, value);
        }
        else
        {
            greater.Enqueue(value, value);
        }

        if (greater.Count == smaller.Count)
            yield return (greater.Peek() - smaller.Peek()) / 2;
        else
            yield return -1 * smaller.Peek();
    }
}