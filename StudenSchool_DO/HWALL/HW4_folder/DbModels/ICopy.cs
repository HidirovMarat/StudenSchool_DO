namespace DbModels;

internal interface ICopy<T>
{
    public void Copy(T fromT);
}
