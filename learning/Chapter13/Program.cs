
using Chapter13;

List<int> list = new()
{
    1,2,4,5,2,1
};

//var res = SimpleSort1.BubbleSort(list, SimpleSort1.GreaterThan);

//var res = SimpleSort1.BubbleSort(list,
//    (int first, int second) =>
//    {
//        return first > second;
//    });
var res = SimpleSort1.BubbleSort(list,
    (first, second) =>
    {
        return first > second;
    });
Console.WriteLine(string.Join(", ", res));


Console.ReadKey();