////////////////////
// Egemen Ciftci //
//////////////////
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
        var value = -item; // Multiply the value with -1 to use min heap as a max heap
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

        if (greater.Count == smaller.Count)
            yield return (greater.Peek() - smaller.Peek()) / 2;
        else
            yield return -smaller.Peek();
    }
}