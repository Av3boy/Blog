using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Blog.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ObservableCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static ObservableCollection<T> Range<T>(this ObservableCollection<T> sequence, int start, int count)        
            => new ObservableCollection<T>(sequence.Skip(start).Take(count));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
            => new ObservableCollection<T>(list);
    }
}
