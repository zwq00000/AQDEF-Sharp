using System.Collections.Generic;

namespace AQDEF.Sharp.Models {
    public abstract class BaseEnties {
        private readonly IDictionary<string, IKKeyEntry> _entries;

        protected BaseEnties(int index) {
            _entries = new SortedDictionary<string, IKKeyEntry>();
            this.Index = index;
        }

        protected BaseEnties(IKKeyEntry entry) : this(entry.Index) {
            this.Add(entry);
        }

        #region Getter/Setter

        private IKKeyEntry GetSharedEntry(string key) {
            if (SharedEnties == null) {
                return null;
            }
            IKKeyEntry entry;
            if (SharedEnties._entries.TryGetValue(key, out entry)) {
                return entry;
            }
            return null;

        }

        /// <summary>
        /// 获取记录条目,先匹配共享条目
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IKKeyEntry GetEntry(string key) {
            IKKeyEntry entry;
            if (_entries.TryGetValue(key, out entry)) {
                return entry;
            }
            return GetSharedEntry(key);
        }

        public object GetValue(string key) {
            IKKeyEntry entry = GetEntry(key);
            if (entry != null) {
                return entry.Key.Converter.Convert((string)entry.Text);
            }
            return null;
        }

        protected T GetValue<T>(string key) {
            IKKeyEntry entry = GetEntry(key);
            if (entry != null) {
                return (T)entry.Value;
            }
            return default(T);
        }

        protected T GetValue<T>(KKey key) {
            return GetValue<T>(key.Key);
        }

        protected void SetValue<TV>(string key, TV value) {
            IKKeyEntry entry;
            if (!_entries.TryGetValue(key, out entry)) {
                entry = new KKeyEntry(KKey.Of(key), this.Index, string.Empty);
                this.Add(entry);
            }
            entry.SetValue(value);
        }

        protected void SetValue(KKey key, object value) {
            IKKeyEntry entry;
            if (!_entries.TryGetValue(key.Key, out entry)) {
                entry = new KKeyEntry(key);
                _entries.Add(key.Key, entry);
            }
            entry.SetValue(value);
        }

        #endregion

        protected internal BaseEnties SharedEnties { get; set; }

        /// <summary>
        /// 节点索引
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// entry Level
        /// </summary>
        public abstract KKeyLevel Level { get; }

        public ICollection<IKKeyEntry> Entries => _entries.Values;

        protected void ThrowIfNotCheckLevel(KKeyLevel entryLevel) {
            if ((entryLevel & Level) != entryLevel) {
                throw new AqdefValidityException($"entry level is {entryLevel},request {Level}");
            }
        }

        /// <summary>
        /// 向字典中增加条目
        /// </summary>
        /// <param name="entry"></param>
        public virtual void Add(IKKeyEntry entry) {
            ThrowIfNotCheckLevel(entry.Key.Level);
            //check Index
            var key = entry.Key.Key;
            if (_entries.ContainsKey(key)) {
                _entries[key] = entry;
            } else {
                _entries.Add(entry.Key.Key, entry);
            }
        }
    }
}