namespace HubTask.Helpers
{
    public class DocumentSettings
    {
        public static string UplaodFile(IFormFile file, string foldername)
        {
            var FolderPass = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", foldername);
            var filename = $"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";  //Unique , get pring it with jbg ...

            var filepath = Path.Combine(FolderPass, filename);
            using var FStream = new FileStream(filepath, FileMode.Create); //using because it outside CLR
            file.CopyTo(FStream);
            return filename;
        }
        public static void DeleteFile(string file, string foldername)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", foldername, file);
            if (File.Exists(filepath))
                File.Delete(filepath);
        }
    }
}
