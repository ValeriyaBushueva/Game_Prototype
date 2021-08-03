
public interface IData<T>
{
  public void Save(T data, string path = null);
   T Load(string path = null);
}
