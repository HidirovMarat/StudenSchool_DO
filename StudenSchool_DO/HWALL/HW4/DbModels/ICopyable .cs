namespace DbModels;

internal interface ICopyable<T>
{
    public void Copy(T fromT);
}
