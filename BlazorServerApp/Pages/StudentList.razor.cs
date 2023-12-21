using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Drawing.Printing;

namespace BlazorServerApp.Pages
{
    public partial class StudentList
    {
        [Inject] IStudentService studentService { get; set; }
        [Inject] IClassService classService { get; set; }
        [Inject] IStudentRepository studentRepository { get; set; }
        [Inject] StudentMapper studentMapper { get; set; }

        [Inject] IMessageService messageService { get; set; }

        public List<Student> students = new();
        public Student student = new Student();

        protected StudentFilter studentFilter = new StudentFilter();
        private PageView<Student> pagedData = new PageView<Student>();
        private List<StudentViewDto> studentViews = new List<StudentViewDto>();
        private List<Class> classes = new List<Class>();

        StudentForm StudentForm;

        int _pageIndex = 1;
        int _pageSize = 5;
        int _total = 0;
        private EditForm _formSearchList;
        ITable table;
        int formMode = 1;
        protected override async Task OnInitializedAsync()
        {
            classes = classService.GetAllClasses();
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            pagedData = await studentService.GetDataPageAsync(_pageIndex, _pageSize, studentFilter);
            studentViews = studentMapper.MapListToListViewDtoWithIndex(pagedData.Data, _pageSize * (_pageIndex - 1));
            _total = pagedData.PageCount;
            StateHasChanged();
        }

        private async void OnFinishSearchAsync(EditContext editContext)
        {
            _pageIndex = 1;
            await LoadDataAsync();
            Console.WriteLine("Enter");
        }

        private void OnFinishFailedSearch(EditContext editContext)
        {
            studentFilter = new StudentFilter();
        }

        public async Task OnPagingAsync()
        {
            await LoadDataAsync();
        }

        private async void ReloadListAsync()
        {
            _pageIndex = 1;
            await LoadDataAsync();
        }

        private async Task SearchAsync(StudentFilter student)
        {
            studentFilter = student;
            _pageIndex = 1;
            await LoadDataAsync();
        }

        public void Clear()
        {
            student = new Student();
            StudentForm.student = new Student();
            StudentForm.formMode = 1;
            formMode = 1;
            studentFilter = new StudentFilter();
            ReloadListAsync();
        }

        private void UpdateStudent(StudentViewDto studentView)
        {
            student = studentService.GetStudentById(studentView.Id);
            StudentForm.formMode = 2;
            StudentForm.student = student;
            StudentForm.Open();
            ReloadListAsync();
        }

        private void DeleteStudent(StudentViewDto studentView)
        {
            student = studentService.GetStudentById(studentView.Id);
            studentService.DeleteStudent(student);
            messageService.Success("Xóa thành công");
            ReloadListAsync();
        }

    }
}
