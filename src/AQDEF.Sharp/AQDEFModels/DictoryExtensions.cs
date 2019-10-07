using System;
using System.Collections.Generic;

namespace AQDEF.Sharp.AQDEFModels {
    internal static class DictoryExtensions {

        public static TValue GetValueOrNull<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) {
            TValue value;
            dictionary.TryGetValue(key, out value);
            return value;
        }

        public static TValue putIfAbsent<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key,
            TValue value) {
            if (dictionary.ContainsKey(key)) {
                return dictionary[key];
            } else {
                dictionary.Add(key, value);
                return value;
            }
        }

        public static void forEach<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            Action<TKey, TValue> eachAction) {
            foreach (var entry in dictionary) {
                eachAction(entry.Key, entry.Value);

            }
        }

        public static void forEach<TValue>(this IEnumerable<TValue> dictionary,
            Action<TValue> eachAction) {
            foreach (var entry in dictionary) {
                eachAction(entry);
            }
        }

        public static TValue computeIfAbsent<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,TKey key,
            Func<TKey,TValue> action) {
            TValue value;
            if (dictionary.TryGetValue(key, out value)) {
                return value;
            }
            value = action(key);
            dictionary.Add(key,value);
            return value;
        }
    }
}