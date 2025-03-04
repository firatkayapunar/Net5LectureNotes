using Microsoft.AspNetCore.Mvc;
using Net5LectureNotes.ViewModelAndDTO.Models.ViewModels;

namespace Net5LectureNotes.ViewModelAndDTO.Controllers
{
    public class PersonnelController : Controller
    {
        // Kullanıcılardan gelen veriler kesinlikle veritabanı tablolarının karşılığı olan entitiy modelleri olmamalıdır. ViewModel olarak alınmalıdır. Tüm Validation'lar bu ViewModel nesneleri üzerinde gerçekleştirilmelidir.

        // Kullanıcıdan gelen dataları ViewModel ile karşıladıktan sonra bu ViewModel'da ki verileri veritabanına kaydetmek isteyebiliriz. Bu durumda, bu verileri Entity Model'a dönüştürmemiz gerekecektir. Bunun için farklı yöntemler kullanabiliriz. AutoMapper en çok tercih edilen yöntemdir.
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonnelCreateVM personnelCreateVM)
        {
            return View();
        }
    }
}
