namespace Model
{
    public class EmployeeDto : Employee
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }

        public string AccessGroupName { get; set; }

        private string empFullName;
        
        public string EmpFullName {
            get => EmpFname + " " + EmpLname;
            set => empFullName = value;
        }
        
    }
}