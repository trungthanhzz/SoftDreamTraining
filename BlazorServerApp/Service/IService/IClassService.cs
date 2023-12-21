namespace BlazorServerApp
{
    public interface IClassService
    {
        /// <summary>
        /// Lấy ra danh sách tất cả lớp học
        /// </summary>
        /// <returns></returns>
        public List<Class> GetAllClasses();

        /// <summary>
        /// Lấy ra lớp học với id tương ứng
        /// </summary>
        /// <param name="id">Số định danh</param>
        /// <returns></returns>
        public Class GetClassById(int id);

    }
}
