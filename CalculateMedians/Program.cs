/*|||||||||||||||||||||||
||||  Egemen Ciftci  ||||
|||||||||||||||||||||||*/
var array = new double[] { 5, 2, 1, 4, 3 };
var medians = CalculateMedians(array);
Console.WriteLine(string.Join(" ", medians));

static IEnumerable<double> CalculateMedians(IEnumerable<double> input)
{
    // Declare two min heaps
    var smaller = new PriorityQueue<double, double>(); // The values of this priority queue will be multiplied by -1 to convert it to a max heap.
    var greater = new PriorityQueue<double, double>();

    foreach (var item in input)
    {
        var value = -item;
        value = -smaller.EnqueueDequeue(value, value); // Add value to the left side and remove max value from the left side

        if (greater.Count == smaller.Count)
        {
            value = -greater.EnqueueDequeue(value, value); // Add value to the right side and remove min value from the right side
            smaller.Enqueue(value, value); // Add value to the left side
        }
        else
        {
            greater.Enqueue(value, value); // Add value to the right side
        }

        if (greater.Count == smaller.Count)
            yield return (greater.Peek() - smaller.Peek()) / 2; // There are two values in the middle
        else
            yield return -smaller.Peek(); // Middle value is at the left side
    }
}