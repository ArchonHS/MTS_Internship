/// <summary>
/// Возвращает отсортированный по возрастанию поток чисел
/// </summary>
/// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
/// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
/// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
/// <returns>Отсортированный по возрастанию поток чисел.</returns>


namespace Task4
{
    class Program
    {

        static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
            if (inputStream.Count() <= 1000000000 && sortFactor > 0 && maxValue >= 0 && maxValue <= 2000)
            {
                List<int> filteredStream = new List<int>();
                int x = Int32.MinValue;
                foreach (int item in inputStream)
                {
                    if (item <= maxValue && item >= 0)
                    {
                        if (item > x)
                        {
                            x = item;
                        }
                        if (item >= x - sortFactor)
                        {
                            filteredStream.Add(item);
                        }
                    }
                }
                //return QuickSort(filteredStream);
                return filteredStream.OrderBy(item => item);
            }
            else return new List<int>();
        }

        static List<int> QuickSort(List<int> array)
        {
            if (array.Count <= 1)
                return new List<int>(array);
            int pivotIndex = array.Count / 2;
            int pivot = array[pivotIndex];
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < array.Count; i++)
            {
                if (i == pivotIndex)
                    continue;
                if (array[i] <= pivot)
                {
                    left.Add(array[i]);
                }
                else
                {
                    right.Add(array[i]);
                }
            }

            List<int> sorted = QuickSort(left);
            sorted.Add(pivot);
            sorted.AddRange(QuickSort(right));
            return sorted;
        }

        static void PrintResult(IEnumerable<int> arr)
        {
            foreach (int item in arr)
            {
                Console.Write(String.Format("{0}, ", item));
            }
        }
        static void Main(string[] args)
        {
            IEnumerable<int> stream = new int[] { 11, 2, 1, 2, 6, 11, 12, 7, 510, 224, 114, 106, 85, 4, 7 };
            PrintResult(Sort(stream, 5, 150));
        }

    }

}