using System.Collections.Generic;

namespace Snaplight.Extension
{
    public static class QueueEX
    {
        public static void Enqueue<T>(this Queue<T> queue, T item, int count)
        {
            for (int i = 0; i < count; i++)
            {
                queue.Enqueue(item);
            }
        }

        public static void Enqueue<T>(this Queue<T> queue, List<T> items)
        {
            foreach (T item in items)
            {
                queue.Enqueue(item);
            }
        }
    }
}