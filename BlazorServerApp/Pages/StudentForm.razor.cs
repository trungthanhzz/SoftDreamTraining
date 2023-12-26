using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using OneOf.Types;
using System.Linq.Expressions;

namespace BlazorServerApp.Pages
{
    public partial class StudentForm
    {
        [Inject] StudentMapper StudentMapper { get; set; }
        [Inject] IStudentService StudentService { get; set; }
        [Inject] IClassService ClassService { get; set; }
        [Parameter] public EventCallback EventCallback { get; set; }
        [Parameter] public Action Clear { get; set; }

        private List<Class> Classes = new List<Class>();
        public Student Student = new Student();
        public StudentDto StudentDto = new StudentDto();

        private EditForm editForm;

        bool visible = false;



        protected override void OnInitialized()
        {
            Classes = ClassService.GetAllClasses();
            base.OnInitialized();
        }

        //create new student
        private async void Submit()
        {
            try
            {
                bool result = false;
                if (Student.Id == 0)
                {
                    Student = StudentMapper.MapDtoToEntity(StudentDto);
                    result = StudentService.AddNewStudent(Student);
                }
                else
                {
                    Student = StudentMapper.MapDtoToEntity(StudentDto);
                    result = StudentService.UpdateStudent(Student);
                }
                if (result)
                {
                    Success();
                    SubmitTrue();
                }
                else
                {
                    Error();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        private void SubmitFalse()
        {
            Error();
        }
        public void Open()
        {
            StudentDto = StudentMapper.MapEntityToDto(Student);
            visible = true;
        }

        public void Close()
        {
            visible = false;
        }

        public void SubmitTrue ()
        {
            Clear?.Invoke();
            visible = false;

        }

        private void Error()
        {
            messageService.Error("Something when wrong");
        }
        private void Success()
        {
            Console.WriteLine("Success");
            messageService.Success("Thao tác thành công");
        }
    }
}
