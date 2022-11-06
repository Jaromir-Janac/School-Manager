using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolWebApp.Services;
using SchoolWebApp.ViewModels;

namespace SchoolWebApp.Controllers {
    public class GradesController : Controller {
        GradesService _service;
        public GradesController(GradesService service) {
            _service = service;
        }
        public async Task<IActionResult> Index() {
            var allGrades = await _service.GetAllAsync();
            return View(allGrades);
        }
        public async Task<IActionResult> CreateAsync() {
            var gradesDropdownsData = await _service.GetGradesDropdownsValues();
            ViewBag.Students = new SelectList(gradesDropdownsData.Students, "Id", "LastName");
            ViewBag.Subjects = new SelectList(gradesDropdownsData.Subjects, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GradesVM newGrade) {
            await _service.CreateAsync(newGrade);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id) {
            var gradeToEdit = await _service.GetByIdAsync(id);
            if (gradeToEdit == null) {
                return View("Not Found");
            }
            GradesVM grade = new GradesVM() {
                Id = gradeToEdit.Id,
                StudentId = gradeToEdit.Student.Id,
                SubjectId = gradeToEdit.Subject.Id,
                What = gradeToEdit.What,
                Mark = gradeToEdit.Mark,
                Date = gradeToEdit.Date
            };

            var gradesDropdownsData = await _service.GetGradesDropdownsValues();
            ViewBag.Students = new SelectList(gradesDropdownsData.Students, "Id", "LastName");
            ViewBag.Subjects = new SelectList(gradesDropdownsData.Subjects, "Id", "Name");

            return View(grade);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, GradesVM updatedGrade) {
            await _service.UpdateAsync(id, updatedGrade);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAsync(int id) {
            var gradeToDelete = await _service.GetByIdAsync(id);
            if (gradeToDelete == null) {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
