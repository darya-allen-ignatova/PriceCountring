namespace PriceApp.BusinessLogic.FileService
{
    public class FileModel
    {
        public string FolderPath { get; set; }
        public string FileName { get; set; }
        public FileExtension FileExtension { get; set; }

        public string FullPath
        {
            get =>  $@"{FolderPath}\{FileName}.{FileExtension}";
        }
    }
}
