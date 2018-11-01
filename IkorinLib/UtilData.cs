using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace IkorinLib
{
    public static class UtilData
    {
        /// <summary>オブジェクトのDeep Copyを行います。</summary>
        /// <typeparam name="T">対象の型</typeparam>
        /// <param name="obj">コピーするオブジェクト</param>
        /// <returns>コピーオブジェクト</returns>
        public static T DeepCopy<T>(T obj)
        {
            var bf = new BinaryFormatter();
            try {
                using(var ms = new MemoryStream()) {
                    bf.Serialize(ms, obj);
                    ms.Position = 0;
                    var result = (T)bf.Deserialize(ms);
                    return result;
                }
            }
            catch(Exception ex) {
                throw new InvalidOperationException("DeepCopyに失敗しました。対象がSerializable属性を持たないクラスを含んでいる可能性があります。", ex);
            }
        }
    }
}
