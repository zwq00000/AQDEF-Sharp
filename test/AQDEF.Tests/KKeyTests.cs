using System;
using System.Collections.Generic;
using AQDEF.Sharp;
using Xunit;

namespace AQDEF.Tests
{
    public class KKeyTests
    {
        [Fact]
        public void TestOf() {

            var key = KKey.Of("K1001");
            Assert.NotNull(key);
            Assert.Equal("K1001", key.Key);
        }

        /// <summary>
        /// two different K-keys are not equals
        /// </summary>
        [Fact]
        public void TestDiffentKKeys() {
            Assert.True(KKey.Of("K1001") != KKey.Of("K1002"), "two different K-keys are not equals");

            Assert.True(KKey.Of("K1001")== KKey.Of("K1001"), "two same K-keys are the same instances (they are fetched from cache)");

            //two same K-keys are the same instances (they are fetched from cache)
            Assert.Equal(KKey.Of("K1001"), KKey.Of("K1001"));

            List<KKey> klice = new List<KKey>();
            for (int i = 0; i < 10000; i++) {
                klice.Add(KKey.Of("K" + i));
            }
            Assert.Equal(10000, klice.Count);
        }
    }

    public class KKRepositoryTest {

        [Fact]
        public void TestDefaultProvider() {
            var provider = new KKeyRepository.DefaultKKeyProvider();
            var metadata = provider.CreateKKeysWithMetadata();
            Assert.NotEmpty(metadata.Keys);
            Assert.NotEmpty(metadata.Values);
        }

        [Fact]
        public void TestRepository() {
            var repository = KKeyRepository.getInstance();
            var keys = repository.GetAllKKeys();
            Assert.NotEmpty(keys);
            foreach (var key in keys) {
                var kKey = KKey.Of(key);
                Console.WriteLine($"{kKey.Key} {kKey.DbColumnName} {kKey.DisplayName}");
            }
        }

        /// <summary>
        /// k-key is correctly mapped to column name
        /// </summary>
        [Fact]
        public void TestColumnName() {
            var column = KKeyRepository.getInstance().GetMetadataFor(KKey.Of("K0001"));
            Assert.Equal(column.ColumnName, "WVWERTNR");
        }
    }
}
