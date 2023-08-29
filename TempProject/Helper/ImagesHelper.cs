namespace TempProject.Helper
{
    public static class ImagesHelper
    {
        public static string uploadImg(IFormFile file, string FolderName)
        {
            string FolderPathe = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FolderName);

            string FileName = $"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";

            string FilePath = Path.Combine(FolderPathe, FileName);


            using FileStream FS = new FileStream(FilePath, FileMode.Create);

            file.CopyTo(FS);

            return FileName;

        }
    }
}
