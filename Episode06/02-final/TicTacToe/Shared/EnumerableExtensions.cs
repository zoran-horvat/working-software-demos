using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Shared
{
    static class EnumerableExtensions
    {
        public static IEnumerable<T> WithParity<T>(this IEnumerable<T> seq, int parity) =>
            seq.Select((obj, offset) => (obj, offset))
                .Where(tuple => tuple.offset % 2 == parity)
                .Select(tuple => tuple.obj);
    }
}
