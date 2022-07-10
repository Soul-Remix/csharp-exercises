using Teleprompter;

static IEnumerable<string> ReadFrom(string file)
{
    string? line;
    using (var reader = File.OpenText(file))
    {
        while ((line = reader.ReadLine()) != null)
        {
            var words = line.Split(' ');
            var lineLength = 0;
            foreach (var word in words)
            {
                yield return word + " ";
                lineLength += word.Length + 1;
                if (lineLength > 70)
                {
                    yield return Environment.NewLine;
                    lineLength = 0;
                }
            }
            yield return Environment.NewLine;
        }
    }
}

static async Task GetInput(TeleConfig config)
{
    int Delay = config.Delay;

    Action work = () =>
    {
        do
        {
            var key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                case '+':
                    config.UpdateDelay(-20);
                    break;
                case '-':
                    config.UpdateDelay(20);
                    break;
                case 'x':
                case 'X':
                    config.setDone();
                    break;
            }

        } while (!config.Done);
    };
    await Task.Run(work);
}

static async Task ShowTele(TeleConfig config)
{
    var lines = ReadFrom("sampleQuotes.txt");
    foreach (var line in lines)
    {
        Console.Write(line);
        if (!String.IsNullOrWhiteSpace(line))
        {

            await Task.Delay(config.Delay);
        }
    }
    config.setDone();
}

static async Task RunTele()
{
    var Config = new TeleConfig();
    var InputTask = GetInput(Config);
    var ShowTask = ShowTele(Config);
    await Task.WhenAll(InputTask, ShowTask);
}

RunTele().Wait();