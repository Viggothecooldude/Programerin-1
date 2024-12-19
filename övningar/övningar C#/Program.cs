string text = "abc@example.com";
string[] strings = text.Split('.', '@');
for (int i = 0; i < strings.Length; i++)
{
    Console.WriteLine(strings[i]);
}