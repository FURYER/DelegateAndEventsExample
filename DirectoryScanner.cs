using System;
using System.IO;

public class DirectoryScanner
{
    public event EventHandler<FileArgs> FileFound;

    public void ScanDirectory(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
            throw new DirectoryNotFoundException($"Directory '{directoryPath}' not found.");

        foreach (var file in Directory.GetFiles(directoryPath))
        {
            var args = new FileArgs { FileName = file };
            OnFileFound(args);

            // Если поиск был отменен, прерываем цикл
            if (args.Cancel)
            {
                Console.WriteLine("Search canceled.");
                break;
            }
        }
    }

    protected virtual void OnFileFound(FileArgs e)
    {
        FileFound?.Invoke(this, e);
    }
}

public class FileArgs : EventArgs
{
    public string FileName { get; set; }
    public bool Cancel { get; set; }
}
