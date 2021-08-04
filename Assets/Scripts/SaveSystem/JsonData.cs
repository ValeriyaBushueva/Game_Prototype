using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonData<T> : IData<T>
{
    public void Save(T data, string path = null)
      {
         var str = JsonConvert.SerializeObject(data, Formatting.Indented);
         File.WriteAllText(path, Crypto.CryptoXOR(str)); 
      }

      public T Load(string path = null)
      {
         var str = File.ReadAllText(path);
         str = Crypto.CryptoXOR(str);
         
         Debug.Log(str);

         var result = JsonConvert.DeserializeObject<T>(str);
         
         return result;
      }
   }


