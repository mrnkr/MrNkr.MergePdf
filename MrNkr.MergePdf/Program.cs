using MrNkr.MergePdf.Core;

Console.WriteLine("Merge some PDFs");

MergedPdfBuilder builder = new();

while (true)
{
    Console.Write("Insert the path to a pdf file >> ");
    string? path = Console.ReadLine();

    if (string.IsNullOrEmpty(path))
    {
        break;
    }

    if (!File.Exists(path))
    {
        Console.WriteLine("File does not exist, try again");
        continue;
    }

    if (!path.EndsWith(".pdf"))
    {
        Console.WriteLine("File does not seem to have the right extension, try again");
        continue;
    }

    builder.AddFile(path);
}

while (true)
{
    Console.Write("Insert the path to the output file >> ");
    string? path = Console.ReadLine();

    if (string.IsNullOrEmpty(path))
    {
        Console.WriteLine("Please define where the output should be saved");
        continue;
    }

    if (File.Exists(path))
    {
        Console.WriteLine("File already exists, try again");
        continue;
    }

    if (!path.EndsWith(".pdf"))
    {
        Console.WriteLine("File does not seem to have the right extension, try again");
        continue;
    }

    builder.SaveAs(path);
    break;
}

builder.Build();