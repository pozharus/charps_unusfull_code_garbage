using NLog;

namespace CopyFiles
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static int recursionCounter = 0;
        private static void MoveFiles(string src, string dst)
        {
            var srcDir = new DirectoryInfo(src);
            var dstDir = new DirectoryInfo(dst);
            logger.Info($"Copying files {srcDir.GetFiles().Length} from {src} to {dst}...");
            foreach (var file in srcDir.GetFiles())
            {
                logger.Info(file);
                file.MoveTo($"{dstDir.FullName}/{file.Name}");
            }
        }

        private static void DeleteNested(string src, string dst)
        {
            logger.Debug($"Call DeleteNested {++recursionCounter} times");
            logger.Debug($"src dir: {src}");
            logger.Debug($"dst dir: {dst}");
            logger.Debug($"Count dirs inside {src}: {Directory.GetDirectories(src).Length}");
            if (Directory.GetDirectories(src).Length != 0)
            {
                logger.Debug($"Process directories inside: {src}");
                string[] dirs = Directory.GetDirectories(src);
                foreach (var path in dirs)
                {
                    var dir = new DirectoryInfo(path);
                    logger.Debug($"Process directory: {dir.FullName}");
                    Directory.CreateDirectory($"{dst}/{dir.Name}");
                    MoveFiles(dir.FullName, $"{dst}/{dir.Name}");
                    if (dir.GetDirectories().Length != 0)
                    {
                        DeleteNested($"{src}/{dir.Name}", $"{dst}/{dir.Name}");
                    }
                    Directory.Delete(dir.FullName);
                }
            }
            else
            {
                logger.Debug($"Break recursion");
                return;
            }
        }
        
        public static void Main(string[] args)
        {
            if (args.Length is < 2 or > 3)
            {
                logger.Error("Expected from 2 to 3 parameters");
                logger.Error("1st - source directory, 2nd - destination directory, 3nd (optional) -- nested key");
                return;
            }

            if (Directory.Exists(args[0]) && Directory.Exists(args[0]))
            {
                if (args.Length == 2)
                {
                    MoveFiles(args[0], args[1]);
                }
                else if (args.Length == 3)
                {
                    MoveFiles(args[0], args[1]);
                    DeleteNested(args[0], args[1]);
                }
            }
            else
            {
                logger.Error("Check if passed directories are exists");
            }
        }
    }
}