int n1 =  await SquareAsync(5);
int n2 =  await SquareAsync(6);
Console.WriteLine($"n1={n1}  n2={n2}"); // n1=25  n2=36

async Task<int> SquareAsync(int n)
{
    await Task.Delay(10000);
    return n * n;
}