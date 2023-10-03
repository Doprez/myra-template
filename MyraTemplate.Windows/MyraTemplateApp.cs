using Stride.Engine;

namespace MyraTemplate
{
    class MyraTemplateApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
