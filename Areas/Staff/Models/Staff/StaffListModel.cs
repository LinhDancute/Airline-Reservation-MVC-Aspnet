namespace App.Areas.Staff
{
    public class StaffListModel
    {
        public int totalStaffs { get; set; }
        public int countPages { get; set; }

        public int ITEMS_PER_PAGE { get; set; } = 10;

        public int currentPage { get; set; }

        public List<StaffAndRole> staffs { get; set; }

    }

    public class StaffAndRole : App.Models.Staff.Staff
    {
        public string RoleNames { get; set; }
    }
}