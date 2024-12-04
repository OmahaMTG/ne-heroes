//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using System.IO.Compression;


//namespace WebSite.Pages.Heroes
//{
//    public class UploadCsvModel : PageModel
//    {
//        public async Task<IActionResult> OnPostUploadAsync()
//        {
//            using (var memoryStream = new MemoryStream())
//            {
//                //await FileUpload.FormFile.CopyToAsync(memoryStream);

//                //// Upload the file if less than 2 MB
//                //if (memoryStream.Length < 2097152)
//                //{
//                //    var file = new AppFile()
//                //    {
//                //        Content = memoryStream.ToArray()
//                //    };

//                //    _dbContext.File.Add(file);

//                //    await _dbContext.SaveChangesAsync();
//                //}
//                //else
//                //{
//                //    ModelState.AddModelError("File", "The file is too large.");
//                //}
//            }

//            return Page();
//        }
//    }
//}
