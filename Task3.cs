namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            foreach (var v in new[] { 1, 2, 3, 4 }.EnumerateFromTail(2))
            {
                Console.WriteLine(String.Format("({0}, {1})", v.item, v.tail));
            }

        }

    }
    public static class NewEnumerable
    {
        /// <summary>
        /// <para> Отсчитать несколько элементов с конца </para>
        /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
        /// </summary> 
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
        /// <returns></returns>
        public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable,
            int? tailLength)
        {
            if (tailLength is null)
                return new List<(T item, int? tail)>();
            List<(T item, int? tail)> result = new List<(T item, int? tail)>();
            var count = enumerable.Count() - 1;
            var remaining = tailLength - 1;
            if (tailLength > count)
                remaining = count;
            foreach (var item in enumerable)
            {
                if (count <= remaining)
                {
                    result.Add((item, count));
                    count--;
                }
                else
                {
                    result.Add((item, null));
                    count--;
                }
            }
            return result;
        }
    }
}