using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using OneOf.Types;
using System.Linq.Expressions;

namespace BlazorServerApp.Pages
{
    public partial class StudentForm
    {
        [Inject] StudentMapper studentMapper { get; set; }
        [Inject] IStudentService studentService { get; set; }
        [Inject] IStudentRepository studentRepository { get; set; }
        [Inject] IClassService classService { get; set; }
        [Inject] IClassRepository classRepository { get; set; }
        [Parameter] public EventCallback eventCallback { get; set; }

        private List<Class> classes = new List<Class>();
        public Student student = new Student();
        bool visible = false;

        public StudentDto studentDto = new StudentDto();

        [Parameter] public Action Clear { get; set; }

        public int formMode = 1;

        private EditForm editForm;

        protected override void OnInitialized()
        {
            classes = classRepository.GetAllClasses();
            base.OnInitialized();
        }

        //create new student
        private async void Submit()
        {
            try
            {
                bool result = false;
                student = studentMapper.MapDtoToEntity(studentDto, formMode);
                if (formMode == 1)
                {
                    result = studentRepository.AddNewStudent(student);

                }
                else if (formMode == 2)
                {
                    result = studentRepository.UpdateStudent(student);
                }
                if (result)
                {
                    Success();
                    //await eventCallback.InvokeAsync();
                }
                else
                {
                    Error();
                }
                Close();
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
            studentDto = studentMapper.MapEntityToDto(student, formMode);
            visible = true;
        }

        public void Close()
        {
            Clear?.Invoke();
            visible = false;
            //StateHasChanged();
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
